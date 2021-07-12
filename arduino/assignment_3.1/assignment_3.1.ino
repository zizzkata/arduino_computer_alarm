/*Zdravko Zdravkov
*/
#include <PinChangeInterrupt.h>
#include <PinChangeInterruptBoards.h>
#include <PinChangeInterruptPins.h>
#include <PinChangeInterruptSettings.h>
#include <Display.h>
#include <DHT11.h> // more convinient and I want to get humidity
// Display.show(name.c_str());----->need that
const int KEY1 = 8;
const int KEY2 = 9;
const int LED_R = 4;
const int LED_G = 5;
const int LED_B = 6;
const int KNOB = A0;
const int LIGHT = 16;

unsigned long prev_time_RS = 0;
unsigned long prev_time_MON = 0;
unsigned long prev_time_WR = 0;
unsigned long period_KNOB_Start = 0;
unsigned long prev_time1_inter = 0;
unsigned long prev_time2_inter = 0;
unsigned long debounce_period = 300;
unsigned long mode_check_period = 0;// ---> unnecessary thats why i decided to keep it 0
unsigned long sensors_check_period = 600;
unsigned long period_Read_Write = 750;
unsigned long period_KNOB_Change = 3000;


const int MAX_ANGLE = 30;
const int MIN_ANGLE = 0;

int key1State = HIGH;
int key2State = HIGH;
int key1State_prev = HIGH;
int key2State_prev = HIGH;

int min_threshold_knob;
int max_threshold_knob;
int prev_angle;

int mode = 0;
int prev_mode = 0;
int counter_switcher_SENSOR = 0;
int counter_switcher_PORT = 0;
float timeCom = 0;
int k = 0; //

bool alarm = false;
bool wired = false;
bool knob = false;

float temp;
float humid;
float light;
String alarmStatus = "";
int angle = 0;
String line = "";
String timeD = "";


//PCINT is short for pin change interrupt
void pciSetup(byte pin)
{
  *digitalPinToPCMSK(pin) |= bit (digitalPinToPCMSKbit(pin));  // enable pin
  PCIFR  |= bit (digitalPinToPCICRbit(pin)); // clear any outstanding interrupt
  PCICR  |= bit (digitalPinToPCICRbit(pin)); // enable interrupt for the group
}

void setup()
{
  pinMode(KEY1, INPUT_PULLUP);
  pinMode(KEY2, INPUT_PULLUP);
  pinMode(KNOB, INPUT);
  pinMode(LED_R, OUTPUT);
  pinMode(LED_B, OUTPUT);
  //no led green cuz its ***** bright
  Serial.begin(9600);

  angle = (int) Sensor_Readings("knob");
  //min_threshold_knob = (int)Sensor_Readings("knob") - 1;
  //max_threshold_knob = (int)Sensor_Readings("knob") + 1;
  prev_angle = angle;

  // enable interrupt for pin...
  pciSetup(KEY1);
  pciSetup(KEY2);
  //pciSetup(A0);

}

// Use one Routine to handle each group
ISR (PCINT0_vect) // handle pin change interrupt for D8 to D13 here
{
  Button_Click();
}
//////////////////////////////////////////////////////////////////
ISR (PCINT1_vect) // handle pin change interrupt for A0 to A5 here
{
  //aperantly its quite hard to implement this rn
}
//////////////////////////////////////////////////////////////////
ISR (PCINT2_vect) // handle pin change interrupt for D0 to D7 here
{
  //dont need this one
}
//////////////////////////////////////////////////////////////////

void loop()
{
  //TimeComputer("$1212");
  // -- Sensor Change --
  //////////////////////////////////////////////////////////////////
  if (prev_angle != Sensor_Readings("knob"))
  {
    mode = 3;
    prev_angle = angle;
  }

  // knob checker prev version: -> problem: not responsive enough
  /*if ((min_threshold_knob > angle) || (max_threshold_knob < angle))
    {
    min_threshold_knob = angle - 1;
    max_threshold_knob = angle + 1;
    mode = 3;
    }
  */
  /////////////////////////////////////////////////////////////////

  // -- Read/Write from SerialPort --
  /////////////////////////////////////////////////////////////////
  //line = "$12.14";
  //Serial.println(TimeComputer(line));
  if (Serial.available() > 0)
  {
    line = Serial.readStringUntil('\n');

    if (line != "-")
    {
      if (line == "logg_On")
      {
        wired = true;
      }
      else if (line == "logg_Off")
      {
        wired = false;
      }
      else if (line == "alarm_Off")
      {
        alarm = false;
      }
      else if (line.indexOf('$') >= 0 && line.indexOf('$') <= 1)
      {
        timeD = line;
      }
      else
      {
        line = "-";
      }
    }
  }
  if ((unsigned long)(millis() - prev_time_WR) >= period_Read_Write)
  {
    prev_time_WR = millis();

    Serial.println("alarm_s:/" + alarmStatus + '/' + "temp:/" + String(temp) + '/' + "humid:/" + String(humid) + '/' + "head_s:/" + String(angle) + '/' + "light:/" + String(light));

    //if(alarmStatus =="alarm_On")
    //{
    //k++;
    //if(k==3)
    //{
    alarmStatus = "-";
    //k=0;
    //}
    //}
    /* test version
        Serial.print("alarm_s:/" + alarmStatus + '/');
        Serial.print("temp:/" + String(temp) + '/');
        Serial.print("humid:/" + String(humid) + '/');
        Serial.print("head_s:/" + String(angle) + '/');
        Serial.println("light:/" + String(light));
    */
  }
  /////////////////////////////////////////////////////////////////

  // -- Sensor Readings --
  ////////////////////////////////////////////////////////////////
  if ((unsigned long)(millis() - prev_time_RS) >= sensors_check_period ) // gets sensors values
  {
    // it chops the function in 2 parts to lower the load
    prev_time_RS = millis();
    if (counter_switcher_SENSOR == 0)
    {
      temp = Sensor_Readings("temperature");
      humid = Sensor_Readings("humidity");
      counter_switcher_SENSOR++;
    }
    else// chop chop chop chop chop
    {
      light = Sensor_Readings("light");
      angle = (int) Sensor_Readings("knob");
      counter_switcher_SENSOR = 0;
    }
  }
  ///////////////////////////////////////////////////////////////

  // -- Display --
  ///////////////////////////////////////////////////////////////
  if ((unsigned long)(millis() - prev_time_MON) >= mode_check_period) // updates data on arduino
  {
    prev_time_MON = millis();
    if (mode == 1)
    {
      if (wired)//shows only the clock if its connected to the pc
      {
        TimeComputer(timeD);
      }
      else
      {
        Display.show(humid);
      }
    }
    else if (mode == 2)
    {
      Display.show(temp);
    }
    else if (mode == 3)
    {

      Display.show(angle);
    }
    else
    {
      Display.show("    ");
    }

    // checks device status ---> connection and alarm
    if (alarm == true)
    {
      digitalWrite(LED_R, HIGH);
    }
    else
    {
      digitalWrite(LED_R, LOW);
    }
    if (wired == true)
    {
      digitalWrite(LED_G, HIGH);
    }
    else
    {
      digitalWrite(LED_G, LOW);
    }
  }
}
//////////////////////////////////////////////////////////////////


// -- Methods -- INTERUPTION
void Button_Click()
{
  key1State = digitalRead(KEY1);
  key2State = digitalRead(KEY2);

  if (((unsigned long)(millis() - prev_time1_inter) >= debounce_period) && (key1State == LOW))
  {
    prev_time1_inter = millis();
    alarm = true;
    alarmStatus = "alarm_On";

  }
  if (((unsigned long)(millis() - prev_time2_inter) >= debounce_period) && (key2State == LOW))
  {
    prev_time2_inter = millis();
    mode++;
    if (mode == 4)
    {
      mode = 0;
    }
  }
}

// -- Methods/Functios --
float Sensor_Readings(String source)
{
  float value;
  if (source == "temperature")
  {
    value = DHT11.getTemperature();
    if (isnan(value))
    {
      return 0;
    }
    else
    {
      return value;
    }
  }
  else if (source == "humidity")
  {
    value = DHT11.getHumidity();
    if (isnan(value))
    {
      return 0;
    }
    else
    {
      return value;
    }
  }
  else if (source == "knob")
  {
    int reading = analogRead(KNOB);
    //map(value, fromLow, fromHigh, toLow, toHigh)
    int angle = map(reading, 0, 1023, MIN_ANGLE, MAX_ANGLE);
    value = angle;
    return value;
  }
  else if (source == "light")
  {
    int value_ADC = analogRead(LIGHT);
    float resistance_sensor = (float)(1023 - value_ADC) * 10 / value_ADC;

    value = (325 * pow(resistance_sensor, -1.4)) / 1000;
    return value;
  }
  else
  {
    return 0;
  }
}

// -- timer converter --
void TimeComputer(String obj)
{
  String obj2 = obj.substring(1, 5);
  //float part1 = obj.substring(1, 6).toFloat();
  int part1 = (obj2.toInt()) / 1000;
  int part2 = (obj2.toInt()) / 100 - (part1 * 10);
  int part3 = (obj2.toInt()) / 10 - (part1 * 100 + part2 * 10);
  int part4 = (obj2.toInt()) - (part1 * 1000 + part2 * 100 + part3 * 10 );

  Serial.println(obj2);

  Display.showDigitAt(0, part1, false);
  Display.showDigitAt(1, part2, true);
  Display.showDigitAt(2, part3, false);
  Display.showDigitAt(3, part4, false);



  //if()
  //{
  //sum = '0' + String(part1);
  //}
  //else
  //{

  //return part1;
  //}
  /*
    float part1 = obj.substring(0, 2).toFloat();
    float part2 = (obj.substring(3, 5).toFloat()) / 100;
    String sum;
    if(part2<10)
    {
    sum = '0' + String(part1 + part2);
    }
    else
    {
    return sum = String(part1 + part2);
    }
  */
}
