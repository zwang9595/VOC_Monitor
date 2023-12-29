#include <Wire.h>
#include <SparkFun_SGP30_Arduino_Library.h>

SGP30 vox;

#define NUMBER_OF_SENSORS 8

float I, VRx, voltage;
float R0_b, R1_b, R2_b, R3_b, R4_b, R5_b, R6_b, R7_b;
float R_avg_base, R_avg, C_avg, t_avg;
float C0_temp, C1_temp, C2_temp, C3_temp, C4_temp, C5_temp, C6_temp, C7_temp;
float C0, C1, C2, C3, C4, C5, C6, C7;
float t0_temp, t1_temp, t2_temp, t3_temp, t4_temp, t5_temp, t6_temp, t7_temp;
float t0, t1, t2, t3, t4, t5, t6, t7;
float R0_t, R1_t, R2_t, R3_t, R4_t, R5_t, R6_t, R7_t;

int low_switch;

void setup() {
  // put your setup code here, to run once:
  Wire.begin();
  Serial.begin(115200);
  while (!Serial);
  // Wait time for put wire back
  delay(5000);

  //Initialize all SGP30 sensors
  for (byte x = 0; x < NUMBER_OF_SENSORS; x++) {
    enableMuxPort(x);
    if(!vox.begin()) {
      Serial.println("Cannot connect to SGP30.");
      Serial.println("Is the board connected? Is the device ID correct?");
      while(1);
    }
    vox.initAirQuality();
    disableMuxPort(x);
  }

  // Offset for RTDs
  R0_t = 2.4326;
  R1_t = 2.4486;
  R2_t = 2.4426;
  R3_t = 2.4536;
  R4_t = 2.4486;
  R5_t = 2.4486;
  R6_t = 2.4486;
  R7_t = 2.4406;

  // Find the temperature baseline and print
  for (byte y = 0; y < 15; y++) {
    
    // Baseline of RTD 1
    R0_b = 0;
    for(int i = 0; i < 500; i++) {
      int sensorValue = analogRead(15);
  
      voltage = ((sensorValue * (3.31 / 4096.0) - 0.121) * 10000);
      voltage = voltage / 10000;
      
      I = voltage / 988.0;
      VRx = 3.31 - voltage;
      R0_b = R0_b + VRx / I;
    }
    R0_b = R0_b / 500;
    R0_b = R0_b * R0_t - 255.758;

    // Baseline of RTD 2
    R1_b = 0;
    voltage = 0;
    I = 0;
    VRx = 0;
    for(int i = 0; i < 500; i++) {
      int sensorValue = analogRead(33);
  
      voltage = ((sensorValue * (3.31 / 4096.0) - 0.088) * 10000);
      voltage = voltage / 10000;
      
      I = voltage / 989.0;
      VRx = 3.31 - voltage;
      R1_b = R1_b + VRx / I;
    }
    R1_b = R1_b / 500;
    R1_b = R1_b * R1_t - 255.758;

    // Baseline of RTD 3
    R2_b = 0;
    voltage = 0;
    I = 0;
    VRx = 0;
    for(int i = 0; i < 500; i++) {
      int sensorValue = analogRead(14);
  
      voltage = ((sensorValue * (3.31 / 4096.0) - 0.118) * 10000);
      voltage = voltage / 10000;
      
      I = voltage / 991.0;
      VRx = 3.31 - voltage;
      R2_b = R2_b + VRx / I;
    }
    R2_b = R2_b / 500;
    R2_b = R2_b * R2_t - 255.758;

    // Baseline of RTD 4
    R3_b = 0;
    voltage = 0;
    I = 0;
    VRx = 0;
    for(int i = 0; i < 500; i++) {
      int sensorValue = analogRead(27);
  
      voltage = ((sensorValue * (3.31 / 4096.0) - 0.116) * 10000);
      voltage = voltage / 10000;
      
      I = voltage / 990.0;
      VRx = 3.31 - voltage;
      R3_b = R3_b + VRx / I;
    }
    R3_b = R3_b / 500;
    R3_b = R3_b * R3_t - 255.758;

    // Baseline of RTD 5
    R4_b = 0;
    voltage = 0;
    I = 0;
    VRx = 0;
    for(int i = 0; i < 500; i++) {
      int sensorValue = analogRead(26);
  
      voltage = ((sensorValue * (3.31 / 4096.0) - 0.115) * 10000);
      voltage = voltage / 10000;
      
      I = voltage / 984.0;
      VRx = 3.31 - voltage;
      R4_b = R4_b + VRx / I;
    }
    R4_b = R4_b / 500;
    R4_b = R4_b * R4_t - 255.758;

    // Baseline of RTD 6
    R5_b = 0;
    voltage = 0;
    I = 0;
    VRx = 0;
    for(int i = 0; i < 500; i++) {
      int sensorValue = analogRead(25);
  
      voltage = ((sensorValue * (3.31 / 4096.0) - 0.115) * 10000);
      voltage = voltage / 10000;
      
      I = voltage / 988.0;
      VRx = 3.31 - voltage;
      R5_b = R5_b + VRx / I;
    }
    R5_b = R5_b / 500;
    R5_b = R5_b * R5_t - 255.758;

    // Baseline of RTD 7
    R6_b = 0;
    voltage = 0;
    I = 0;
    VRx = 0;
    for(int i = 0; i < 500; i++) {
      int sensorValue = analogRead(12);
  
      voltage = ((sensorValue * (3.31 / 4096.0) - 0.118) * 10000);
      voltage = voltage / 10000;
      
      I = voltage / 992.0;
      VRx = 3.31 - voltage;
      R6_b = R6_b + VRx / I;
    }
    R6_b = R6_b / 500;
    R6_b = R6_b * R6_t - 255.758;

    // Baseline of RTD 8
    R7_b = 0;
    voltage = 0;
    I = 0;
    VRx = 0;
    for(int i = 0; i < 500; i++) {
      int sensorValue = analogRead(13);
  
      voltage = ((sensorValue * (3.31 / 4096.0) - 0.118) * 10000);
      voltage = voltage / 10000;
      
      I = voltage / 989.0;
      VRx = 3.31 - voltage;
      R7_b = R7_b + VRx / I;
    }
    R7_b = R7_b / 500;
    R7_b = R7_b * R7_t - 255.758;

    // Wait 15 secs for SGP initialized
    delay(1000);
  }
  // Baseline of average temp
  R_avg_base = (R0_b + R1_b + R2_b + R3_b + R4_b + R5_b + R6_b + R7_b) / 8;

  C0 = 400.0;
  C1 = 400.0;
  C2 = 400.0;
  C3 = 400.0;
  C4 = 400.0;
  C5 = 400.0;
  C6 = 400.0;
  C7 = 400.0;
  
  t0 = 0.0;
  t1 = 0.0;
  t2 = 0.0;
  t3 = 0.0;
  t4 = 0.0;
  t5 = 0.0;
  t6 = 0.0;
  t7 = 0.0;

  C0_temp = 0.0;
  C1_temp = 0.0;
  C2_temp = 0.0;
  C3_temp = 0.0;
  C4_temp = 0.0;
  C5_temp = 0.0;
  C6_temp = 0.0;
  C7_temp = 0.0;

  t0_temp = 0.0;
  t1_temp = 0.0;
  t2_temp = 0.0;
  t3_temp = 0.0;
  t4_temp = 0.0;
  t5_temp = 0.0;
  t6_temp = 0.0;
  t7_temp = 0.0;

  low_switch = 0;
}

float R0, R1, R2, R3, R4, R5, R6, R7;
int low_alert_count, low_reset_count;

void loop() {
  // R0 c0 t0 read
  R0 = 0;
  C0_temp = 0;
  t0_temp = 0;
  voltage = 0;
  I = 0;
  VRx = 0;
  for(int i = 0; i < 500; i++) {
    int sensorValue = analogRead(15);

    voltage = ((sensorValue * (3.31 / 4096.0) - 0.121) * 10000);
    voltage = voltage / 10000;
    
    I = voltage / 988.0;
    VRx = 3.31 - voltage;
    R0 = R0 + VRx / I;
  }
  R0 = R0 / 500;
  R0 = R0 * R0_t - 255.758;
  
  if(low_switch == 0) {
    enableMuxPort(0);
    vox.measureAirQuality();
  
    for(int i = 0; i < 500; i++) {
        C0_temp = C0_temp + vox.CO2;
    }
    C0_temp = C0_temp / 500;
    
    for(int i = 0; i < 500; i++) {
      t0_temp = t0_temp + vox.TVOC;
    }
    t0_temp = t0_temp / 500;
    disableMuxPort(0);
  }
  else {
    C0 = 400.0;
    t0 = 0.0;
  }

  // R1 c1 t1 read
  R1 = 0;
  C1_temp = 0;
  t1_temp = 0;
  voltage = 0;
  I = 0;
  VRx = 0;
  for(int i = 0; i < 500; i++) {
    int sensorValue = analogRead(33);

    voltage = ((sensorValue * (3.31 / 4096.0) - 0.088) * 10000);
    voltage = voltage / 10000;
    
    I = voltage / 989.0;
    VRx = 3.31 - voltage;
    R1 = R1 + VRx / I;
  }
  R1 = R1 / 500;
  R1 = R1 * R1_t - 255.758;

  if(low_switch == 0) {
    enableMuxPort(1);
    vox.measureAirQuality();
    
    for(int i = 0; i < 500; i++) {
        C1_temp = C1_temp + vox.CO2;
    }
    C1_temp = C1_temp / 500;
    
    for(int i = 0; i < 500; i++) {
      t1_temp = t1_temp + vox.TVOC;
    }
    t1_temp = t1_temp / 500;
    disableMuxPort(1);
  }
  else {
    C1 = 400.0;
    t1 = 0.0;
  }
  
  // R2 c2 t2 read
  R2 = 0;
  C2_temp = 0;
  t2_temp = 0;
  voltage = 0;
  I = 0;
  VRx = 0;
  for(int i = 0; i < 500; i++) {
    int sensorValue = analogRead(14);

    voltage = ((sensorValue * (3.31 / 4096.0) - 0.118) * 10000);
    voltage = voltage / 10000;
    
    I = voltage / 991.0;
    VRx = 3.31 - voltage;
    R2 = R2 + VRx / I;
  }
  R2 = R2 / 500;
  R2 = R2 * R2_t - 255.758;

  if(low_switch == 0) {
    enableMuxPort(2);
    vox.measureAirQuality();
    
    for(int i = 0; i < 500; i++) {
        C2_temp = C2_temp + vox.CO2;
    }
    C2_temp = C2_temp / 500;
    
    for(int i = 0; i < 500; i++) {
      t2_temp = t2_temp + vox.TVOC;
    }
    t2_temp = t2_temp / 500;
    disableMuxPort(2);
  }
  else {
    C2 = 400.0;
    t2 = 0.0;
  }

  // R3 c3 t3 read
  R3 = 0;
  C3_temp = 0;
  t3_temp = 0;
  voltage = 0;
  I = 0;
  VRx = 0;
  for(int i = 0; i < 500; i++) {
    int sensorValue = analogRead(27);

    voltage = ((sensorValue * (3.31 / 4096.0) - 0.116) * 10000);
    voltage = voltage / 10000;
    
    I = voltage / 990.0;
    VRx = 3.31 - voltage;
    R3 = R3 + VRx / I;
  }
  R3 = R3 / 500;
  R3 = R3 * R3_t - 255.758;

  if(low_switch == 0) {
    enableMuxPort(3);
    vox.measureAirQuality();
    
    for(int i = 0; i < 500; i++) {
        C3_temp = C3_temp + vox.CO2;
    }
    C3_temp = C3_temp / 500;
    
    for(int i = 0; i < 500; i++) {
      t3_temp = t3_temp + vox.TVOC;
    }
    t3_temp = t3_temp / 500;
    disableMuxPort(3);
  }
  else {
    C3 = 400.0;
    t3 = 0.0;
  }

  // R4 c4 t4 read
  R4 = 0;
  C4_temp = 0;
  t4_temp = 0;
  voltage = 0;
  I = 0;
  VRx = 0;
  for(int i = 0; i < 500; i++) {
    int sensorValue = analogRead(26);

    voltage = ((sensorValue * (3.31 / 4096.0) - 0.115) * 10000);
    voltage = voltage / 10000;
    
    I = voltage / 984.0;
    VRx = 3.31 - voltage;
    R4 = R4 + VRx / I;
  }
  R4 = R4 / 500;
  R4 = R4 * R4_t - 255.758;

  if(low_switch == 0) {
    enableMuxPort(4);
    vox.measureAirQuality();
    
    for(int i = 0; i < 500; i++) {
        C4_temp = C4_temp + vox.CO2;
    }
    C4_temp = C4_temp / 500;
    
    for(int i = 0; i < 500; i++) {
      t4_temp = t4_temp + vox.TVOC;
    }
    t4_temp = t4_temp / 500;   
    disableMuxPort(4);
  }
  else {
    C4 = 400.0;
    t4 = 0.0;
  }

  // R5 c5 t5 read
  R5 = 0;
  C5_temp = 0;
  t5_temp = 0;
  voltage = 0;
  I = 0;
  VRx = 0;
  for(int i = 0; i < 500; i++) {
    int sensorValue = analogRead(25);

    voltage = ((sensorValue * (3.31 / 4096.0) - 0.115) * 10000);
    voltage = voltage / 10000;
    
    I = voltage / 988.0;
    VRx = 3.31 - voltage;
    R5 = R5 + VRx / I;
  }
  R5 = R5 / 500;
  R5 = R5 * R5_t - 255.758;

  if(low_switch == 0) {
    enableMuxPort(5);
    vox.measureAirQuality();
    
    for(int i = 0; i < 500; i++) {
        C5_temp = C5_temp + vox.CO2;
    }
    C5_temp = C5_temp / 500;
    
    for(int i = 0; i < 500; i++) {
      t5_temp = t5_temp + vox.TVOC;
    }
    t5_temp = t5_temp / 500;    
    disableMuxPort(5);
  }
  else {
    C5 = 400.0;
    t5 = 0.0;
  }

  // R6 c6 t6 read
  R6 = 0;
  C6_temp = 0;
  t6_temp = 0;
  voltage = 0;
  I = 0;
  VRx = 0;
  for(int i = 0; i < 500; i++) {
    int sensorValue = analogRead(12);

    voltage = ((sensorValue * (3.31 / 4096.0) - 0.118) * 10000);
    voltage = voltage / 10000;
    
    I = voltage / 992.0;
    VRx = 3.31 - voltage;
    R6 = R6 + VRx / I;
  }
  R6 = R6 / 500;
  R6 = R6 * R6_t - 255.758;

  if(low_switch == 0) {
    enableMuxPort(6);
    vox.measureAirQuality();
    
    for(int i = 0; i < 500; i++) {
        C6_temp = C6_temp + vox.CO2;
    }
    C6_temp = C6_temp / 500;
    
    for(int i = 0; i < 500; i++) {
      t6_temp = t6_temp + vox.TVOC;
    }
    t6_temp = t6_temp / 500;
    disableMuxPort(6);
  }
  else {
    C6 = 400.0;
    t6 = 0.0;
  }

  // R7 c7 t7 read
  R7 = 0;
  C7_temp = 0;
  t7_temp = 0;
  voltage = 0;
  I = 0;
  VRx = 0;
  for(int i = 0; i < 500; i++) {
    int sensorValue = analogRead(13);

    voltage = ((sensorValue * (3.31 / 4096.0) - 0.118) * 10000);
    voltage = voltage / 10000;
    
    I = voltage / 989.0;
    VRx = 3.31 - voltage;
    R7 = R7 + VRx / I;
  }
  R7 = R7 / 500;
  R7 = R7 * R7_t - 255.758;

  if(low_switch == 0) {
    enableMuxPort(7);
    vox.measureAirQuality();
    
    for(int i = 0; i < 500; i++) {
        C7_temp = C7_temp + vox.CO2;
    }
    C7_temp = C7_temp / 500;
    
    for(int i = 0; i < 500; i++) {
      t7_temp = t7_temp + vox.TVOC;
    }
    t7_temp = t7_temp / 500;  
    disableMuxPort(7);
  }
  else {
    C7 = 400.0;
    t7 = 0.0;
  }

  if(low_switch == 0) {
    // CO2 compensation
    C0_temp = co2_comp(0, C0_temp, C0, R0, R0_b);
    C1_temp = co2_comp(1, C1_temp, C1, R1, R1_b);
    C2_temp = co2_comp(2, C2_temp, C2, R2, R2_b);
    C3_temp = co2_comp(3, C3_temp, C3, R3, R3_b);
    C4_temp = co2_comp(4, C4_temp, C4, R4, R4_b);
    C5_temp = co2_comp(5, C5_temp, C5, R5, R5_b);
    C6_temp = co2_comp(6, C6_temp, C6, R6, R6_b);
    C7_temp = co2_comp(7, C7_temp, C7, R7, R7_b);
    
    t0_temp = TVOC_comp(0, t0_temp, t0, R0, R0_b);
    t1_temp = TVOC_comp(1, t1_temp, t1, R1, R1_b);
    t2_temp = TVOC_comp(2, t2_temp, t2, R2, R2_b);
    t3_temp = TVOC_comp(3, t3_temp, t3, R3, R3_b);
    t4_temp = TVOC_comp(4, t4_temp, t4, R4, R4_b);
    t5_temp = TVOC_comp(5, t5_temp, t5, R5, R5_b);
    t6_temp = TVOC_comp(6, t6_temp, t6, R6, R6_b);
    t7_temp = TVOC_comp(7, t7_temp, t7, R7, R7_b);
    
    low_alert_count = 0;
    R_avg = (R0 + R1 + R2 + R3 + R4 + R5 + R6 + R7) / 8;
    low_alert_count = low_alert_test();

    if(low_alert_count < 6)  {
      C0 = C0_temp;
      C1 = C1_temp;
      C2 = C2_temp;
      C3 = C3_temp;
      C4 = C4_temp;
      C5 = C5_temp;
      C6 = C6_temp;
      C7 = C7_temp;

      t0 = t0_temp;
      t1 = t1_temp;
      t2 = t2_temp;
      t3 = t3_temp;
      t4 = t4_temp;
      t5 = t5_temp;
      t6 = t6_temp;
      t7 = t7_temp;
    }
    else {
      C0 = 400.0;
      C1 = 400.0;
      C2 = 400.0;
      C3 = 400.0;
      C4 = 400.0;
      C5 = 400.0;
      C6 = 400.0;
      C7 = 400.0;

      t0 = 0.0;
      t1 = 0.0;
      t2 = 0.0;
      t3 = 0.0;
      t4 = 0.0;
      t5 = 0.0;
      t6 = 0.0;
      t7 = 0.0;
      for(int i = 0; i < 8; i++) {
        enableMuxPort(i);
        vox.generalCallReset();
        disableMuxPort(i);
      }
      low_switch = 1;
      low_reset_count = 0;
    }
  }
  else {
    low_reset_count = low_reset_count + 1;
    if(low_reset_count == 15) {
      low_switch = 0;
      R0_b = R0;
      R1_b = R1;
      R2_b = R2;
      R3_b = R3;
      R4_b = R4;
      R5_b = R5;
      R6_b = R6;
      R7_b = R7;
      for(int i = 0; i < 8; i++) {
        enableMuxPort(i);
        vox.initAirQuality();
        disableMuxPort(i);
      }
      R_avg_base = (R0_b + R1_b + R2_b + R3_b + R4_b + R5_b + R6_b + R7_b) / 8;
    }
  }
  C_avg = (C0 + C1 + C2 + C3 + C4 + C5 + C6 + C7) / 8;
  t_avg = (t0 + t1 + t2 + t3 + t4 + t5 + t6 + t7) / 8;

  // Print for serial receiver
  Serial.print("HH\t");
  Serial.print(R0);
  Serial.print("\t");
  Serial.print(C0);
  Serial.print("\t");
  Serial.print(t0);
  Serial.print("\t");
  Serial.print(R1);
  Serial.print("\t");
  Serial.print(C1);
  Serial.print("\t");
  Serial.print(t1);
  Serial.print("\t");
  Serial.print(R2);
  Serial.print("\t");
  Serial.print(C2);
  Serial.print("\t");
  Serial.print(t2);
  Serial.print("\t");
  Serial.print(R3);
  Serial.print("\t");
  Serial.print(C3);
  Serial.print("\t");
  Serial.print(t3);
  Serial.print("\t");
  Serial.print(R4);
  Serial.print("\t");
  Serial.print(C4);
  Serial.print("\t");
  Serial.print(t4);
  Serial.print("\t");
  Serial.print(R5);
  Serial.print("\t");
  Serial.print(C5);
  Serial.print("\t");
  Serial.print(t5);
  Serial.print("\t");
  Serial.print(R6);
  Serial.print("\t");
  Serial.print(C6);
  Serial.print("\t");
  Serial.print(t6);
  Serial.print("\t");
  Serial.print(R7);
  Serial.print("\t");
  Serial.print(C7);
  Serial.print("\t");
  Serial.print(t7);
  Serial.print("\t");
  Serial.print(R_avg);
  Serial.print("\t");
  Serial.print(C_avg);
  Serial.print("\t");
  Serial.print(t_avg);
  Serial.print("\tTT");
  Serial.println();
  
  // Wait receiver, can change
  delay(1000);
}

float co2_comp (int sensor_num, float co2_raw, float co2_prev, float temp, float temp_base) {
  float co2_comp;
  float error = 2.5;
  float diff = temp - temp_base;
  float C_diff = 0;
  
  if(abs(diff) < error) {
    switch (sensor_num) {
      case 0:
        C_diff =  (C7 + C1) / 2;
        if((co2_raw - C_diff) > 50) {
          co2_comp = C_diff;
        }
        else {
          co2_comp  = co2_raw;
        }
        break;
      case 1:
        C_diff =  (C0 + C2) / 2;
        if((co2_raw - C_diff) > 50) {
          co2_comp = C_diff;
        }
        else {
          co2_comp  = co2_raw;
        }
        break;
      case 2:
        C_diff =  (C1 + C3) / 2;
        if((co2_raw - C_diff) > 50) {
          co2_comp = C_diff;
        }
        else {
          co2_comp  = co2_raw;
        }
        break;
      case 3:
        C_diff =  (C2 + C4) / 2;
        if((co2_raw - C_diff) > 50) {
          co2_comp = C_diff;
        }
        else {
          co2_comp  = co2_raw;
        }
        break;
      case 4:
        C_diff =  (C3 + C5) / 2;
        if((co2_raw - C_diff) > 50) {
          co2_comp = C_diff;
        }
        else {
          co2_comp  = co2_raw;
        }
        break;
      case 5:
        C_diff =  (C4 + C6) / 2;
        if((co2_raw - C_diff) > 50) {
          co2_comp = C_diff;
        }
        else {
          co2_comp  = co2_raw;
        }
        break;
      case 6:
        C_diff =  (C5 + C7) / 2;
        if((co2_raw - C_diff) > 50) {
          co2_comp = C_diff;
        }
        else {
          co2_comp  = co2_raw;
        }
        break;
      case 7:
        C_diff =  (C0 + C6) / 2;
        if((co2_raw - C_diff) > 50) {
          co2_comp = C_diff;
        }
        else {
          co2_comp  = co2_raw;
        }
        break;
      default:
        // statements
        break;       
    }
  }
  else if(temp < temp_base) {
    switch (sensor_num) {
      case 0:
        if((abs(R7 - R7_b) < error) && (abs(R1 - R1_b) < error)) {
          co2_comp = (C7 + C1) / 2;
        }
        else if(abs(R7 - R7_b) < error) {
          co2_comp = C7;
        }
        else if(abs(R1 - R1_b) < error) {
          co2_comp = C1;
        }
        else {
          co2_comp = 400.0;
        }
        break;
      case 1:
        if((abs(R0 - R0_b) < error) && (abs(R2 - R2_b) < error)) {
          co2_comp = (C0 + C2) / 2;
        }
        else if(abs(R0 - R0_b) < error) {
          co2_comp = C0;
        }
        else if(abs(R2 - R2_b) < error) {
          co2_comp = C2;
        }
        else {
          co2_comp = 400.0;
        }
        break;
      case 2:
        if((abs(R1 - R1_b) < error) && (abs(R3 - R3_b) < error)) {
          co2_comp = (C1 + C3) / 2;
        }
        else if(abs(R1 - R1_b) < error) {
          co2_comp = C1;
        }
        else if(abs(R3 - R3_b) < error) {
          co2_comp = C3;
        }
        else {
          co2_comp = 400.0;
        }
        break;
      case 3:
        if((abs(R2 - R2_b) < error) && (abs(R4 - R4_b) < error)) {
          co2_comp = (C2 + C4) / 2;
        }
        else if(abs(R2 - R2_b) < error) {
          co2_comp = C2;
        }
        else if(abs(R4 - R4_b) < error) {
          co2_comp = C4;
        }
        else {
          co2_comp = 400.0;
        }
        break;
      case 4:
        if((abs(R3 - R3_b) < error) && (abs(R5 - R5_b) < error)) {
          co2_comp = (C3 + C5) / 2;
        }
        else if(abs(R3 - R3_b) < error) {
          co2_comp = C3;
        }
        else if(abs(R5 - R5_b) < error) {
          co2_comp = C5;
        }
        else {
          co2_comp = 400.0;
        }
        break;
      case 5:
        if((abs(R4 - R4_b) < error) && (abs(R6 - R6_b) < error)) {
          co2_comp = (C4 + C6) / 2;
        }
        else if(abs(R4 - R4_b) < error) {
          co2_comp = C4;
        }
        else if(abs(R6 - R6_b) < error) {
          co2_comp = C6;
        }
        else {
          co2_comp = 400.0;
        }
        break;
      case 6:
        if((abs(R5 - R5_b) < error) && (abs(R7 - R7_b) < error)) {
          co2_comp = (C5 + C7) / 2;
        }
        else if(abs(R5 - R5_b) < error) {
          co2_comp = C5;
        }
        else if(abs(R7 - R7_b) < error) {
          co2_comp = C7;
        }
        else {
          co2_comp = 400.0;
        }
        break;
      case 7:
        if((abs(R0 - R0_b) < error) && (abs(R6 - R6_b) < error)) {
          co2_comp = (C4 + C6) / 2;
        }
        else if(abs(R0 - R0_b) < error) {
          co2_comp = C4;
        }
        else if(abs(R6 - R6_b) < error) {
          co2_comp = C6;
        }
        else {
          co2_comp = 400.0;
        }
        break;
      default:
        // statements
        break;
    }  
  }
  else if(temp > temp_base) {
    
    switch (sensor_num) {
      case 0:
        if((abs(R7 - R7_b) < error) && (abs(R1 - R1_b) < error)) {
          co2_comp = (C7 + C1) / 2;
        }
        else if(abs(R7 - R7_b) < error) {
          co2_comp = C7;
        }
        else if(abs(R1 - R1_b) < error) {
          co2_comp = C1;
        }
        else {
          co2_comp = co2_raw - (temp - temp_base) * 62.9289;
          if(co2_comp < 400) {
            co2_comp = 400;
          }
        }
        break;
      case 1:
        if((abs(R0 - R0_b) < error) && (abs(R2 - R2_b) < error)) {
          co2_comp = (C0 + C2) / 2;
        }
        else if(abs(R0 - R0_b) < error) {
          co2_comp = C0;
        }
        else if(abs(R2 - R2_b) < error) {
          co2_comp = C2;
        }
        else {
          co2_comp = co2_raw - (temp - temp_base) * 62.9289;
          if(co2_comp < 400) {
            co2_comp = 400;
          }
        }
        break;
      case 2:
        if((abs(R1 - R1_b) < error) && (abs(R3 - R3_b) < error)) {
          co2_comp = (C1 + C3) / 2;
        }
        else if(abs(R1 - R1_b) < error) {
          co2_comp = C1;
        }
        else if(abs(R3 - R3_b) < error) {
          co2_comp = C3;
        }
        else {
          co2_comp = co2_raw - (temp - temp_base) * 62.9289;
          if(co2_comp < 400) {
            co2_comp = 400;
          }
        }
        break;
      case 3:
        if((abs(R2 - R2_b) < error) && (abs(R4 - R4_b) < error)) {
          co2_comp = (C2 + C4) / 2;
        }
        else if(abs(R2 - R2_b) < error) {
          co2_comp = C2;
        }
        else if(abs(R4 - R4_b) < error) {
          co2_comp = C4;
        }
        else {
          co2_comp = co2_raw - (temp - temp_base) * 62.9289;
          if(co2_comp < 400) {
            co2_comp = 400;
          }
        }
        break;
      case 4:
        if((abs(R3 - R3_b) < error) && (abs(R5 - R5_b) < error)) {
          co2_comp = (C3 + C5) / 2;
        }
        else if(abs(R3 - R3_b) < error) {
          co2_comp = C3;
        }
        else if(abs(R5 - R5_b) < error) {
          co2_comp = C5;
        }
        else {
          co2_comp = co2_raw - (temp - temp_base) * 62.9289;
          if(co2_comp < 400) {
            co2_comp = 400;
          }
        }
        break;
      case 5:
        if((abs(R4 - R4_b) < error) && (abs(R6 - R6_b) < error)) {
          co2_comp = (C4 + C6) / 2;
        }
        else if(abs(R4 - R4_b) < error) {
          co2_comp = C4;
        }
        else if(abs(R6 - R6_b) < error) {
          co2_comp = C6;
        }
        else {
          co2_comp = co2_raw - (temp - temp_base) * 62.9289;
          if(co2_comp < 400) {
            co2_comp = 400;
          }
        }
        break;
      case 6:
        if((abs(R5 - R5_b) < error) && (abs(R7 - R7_b) < error)) {
          co2_comp = (C5 + C7) / 2;
        }
        else if(abs(R5 - R5_b) < error) {
          co2_comp = C5;
        }
        else if(abs(R7 - R7_b) < error) {
          co2_comp = C7;
        }
        else {
          co2_comp = co2_raw - (temp - temp_base) * 62.9289;
          if(co2_comp < 400) {
            co2_comp = 400;
          }
        }
        break;
      case 7:
        if((abs(R0 - R0_b) < error) && (abs(R6 - R6_b) < error)) {
          co2_comp = (C4 + C6) / 2;
        }
        else if(abs(R0 - R0_b) < error) {
          co2_comp = C4;
        }
        else if(abs(R6 - R6_b) < error) {
          co2_comp = C6;
        }
        else {
          co2_comp = co2_raw - (temp - temp_base) * 62.9289;
          if(co2_comp < 400) {
            co2_comp = 400;
          }
        }
        break;
      default:
        // statements
        break;
    }
  }
  return co2_comp;
}

float TVOC_comp (int sensor_num, float t_raw, float t_prev, float temp, float temp_base) {
  float t_comp;
  float error = 2.5;
  float diff = temp - temp_base;
  float t_diff = 0;
  
  if(abs(diff) < error) {
    switch (sensor_num) {
      case 0:
        t_diff =  (t7 + t1) / 2;
        if((t_raw - t_diff) > 50) {
          t_comp = t_diff;
        }
        else {
          t_comp  = t_raw;
        }
        break;
      case 1:
        t_diff =  (t0 + t2) / 2;
        if((t_raw - t_diff) > 50) {
          t_comp = t_diff;
        }
        else {
          t_comp  = t_raw;
        }
        break;
      case 2:
        t_diff =  (t1 + t3) / 2;
        if((t_raw - t_diff) > 50) {
          t_comp = t_diff;
        }
        else {
          t_comp  = t_raw;
        }
        break;
      case 3:
        t_diff =  (t2 + t4) / 2;
        if((t_raw - t_diff) > 50) {
          t_comp = t_diff;
        }
        else {
          t_comp  = t_raw;
        }
        break;
      case 4:
        t_diff =  (t3 + t5) / 2;
        if((t_raw - t_diff) > 50) {
          t_comp = t_diff;
        }
        else {
          t_comp  = t_raw;
        }
        break;
      case 5:
        t_diff =  (t4 + t6) / 2;
        if((t_raw - t_diff) > 50) {
          t_comp = t_diff;
        }
        else {
          t_comp  = t_raw;
        }
        break;
      case 6:
        t_diff =  (t5 + t7) / 2;
        if((t_raw - t_diff) > 50) {
          t_comp = t_diff;
        }
        else {
          t_comp  = t_raw;
        }
        break;
      case 7:
        t_diff =  (t0 + t6) / 2;
        if((t_raw - t_diff) > 50) {
          t_comp = t_diff;
        }
        else {
          t_comp  = t_raw;
        }
        break;
      default:
        // statements
        break;
    }
  }
  else if(temp < temp_base) {
    switch (sensor_num) {
      case 0:
        if((abs(R7 - R7_b) < error) && (abs(R1 - R1_b) < error)) {
          t_comp = (t7 + t1) / 2;
        }
        else if(abs(R7 - R7_b) < error) {
          t_comp = t7;
        }
        else if(abs(R1 - R1_b) < error) {
          t_comp = t1;
        }
        else {
          t_comp = 0.0;
        }
        break;
      case 1:
        if((abs(R0 - R0_b) < error) && (abs(R2 - R2_b) < error)) {
          t_comp = (t0 + t2) / 2;
        }
        else if(abs(R0 - R0_b) < error) {
          t_comp = t0;
        }
        else if(abs(R2 - R2_b) < error) {
          t_comp = t2;
        }
        else {
          t_comp = 0.0;
        }
        break;
      case 2:
        if((abs(R1 - R1_b) < error) && (abs(R3 - R3_b) < error)) {
          t_comp = (t1 + t3) / 2;
        }
        else if(abs(R1 - R1_b) < error) {
          t_comp = t1;
        }
        else if(abs(R3 - R3_b) < error) {
          t_comp = t3;
        }
        else {
          t_comp = 0.0;
        }
        break;
      case 3:
        if((abs(R2 - R2_b) < error) && (abs(R4 - R4_b) < error)) {
          t_comp = (t2 + t4) / 2;
        }
        else if(abs(R2 - R2_b) < error) {
          t_comp = t2;
        }
        else if(abs(R4 - R4_b) < error) {
          t_comp = t4;
        }
        else {
          t_comp = 0.0;
        }
        break;
      case 4:
        if((abs(R3 - R3_b) < error) && (abs(R5 - R5_b) < error)) {
          t_comp = (t3 + t5) / 2;
        }
        else if(abs(R3 - R3_b) < error) {
          t_comp = t3;
        }
        else if(abs(R5 - R5_b) < error) {
          t_comp = t5;
        }
        else {
          t_comp = 0.0;
        }
        break;
      case 5:
        if((abs(R4 - R4_b) < error) && (abs(R6 - R6_b) < error)) {
          t_comp = (t4 + t6) / 2;
        }
        else if(abs(R4 - R4_b) < error) {
          t_comp = t4;
        }
        else if(abs(R6 - R6_b) < error) {
          t_comp = t6;
        }
        else {
          t_comp = 0.0;
        }
        break;
      case 6:
        if((abs(R5 - R5_b) < error) && (abs(R7 - R7_b) < error)) {
          t_comp = (t5 + t7) / 2;
        }
        else if(abs(R5 - R5_b) < error) {
          t_comp = t5;
        }
        else if(abs(R7 - R7_b) < error) {
          t_comp = t7;
        }
        else {
          t_comp = 0.0;
        }
        break;
      case 7:
        if((abs(R0 - R0_b) < error) && (abs(R6 - R6_b) < error)) {
          t_comp = (t4 + t6) / 2;
        }
        else if(abs(R0 - R0_b) < error) {
          t_comp = t4;
        }
        else if(abs(R6 - R6_b) < error) {
          t_comp = t6;
        }
        else {
          t_comp = 0.0;
        }
        break;
      default:
        // statements
        break;
    }  
  }
  else if(temp > temp_base) {
    
    switch (sensor_num) {
      case 0:
        if((abs(R7 - R7_b) < error) && (abs(R1 - R1_b) < error)) {
          t_comp = (t7 + t1) / 2;
        }
        else if(abs(R7 - R7_b) < error) {
          t_comp = t7;
        }
        else if(abs(R1 - R1_b) < error) {
          t_comp = t1;
        }
        else {
          t_comp = t_raw - (temp - temp_base) * 26.6834;
          if(t_comp < 0) {
            t_comp = 0.0;
          }
        }
        break;
      case 1:
        if((abs(R0 - R0_b) < error) && (abs(R2 - R2_b) < error)) {
          t_comp = (t0 + t2) / 2;
        }
        else if(abs(R0 - R0_b) < error) {
          t_comp = t0;
        }
        else if(abs(R2 - R2_b) < error) {
          t_comp = t2;
        }
        else {
          t_comp = t_raw - (temp - temp_base) * 26.6834;
          if(t_comp < 0.0) {
            t_comp = 0.0;
          }
        }
        break;
      case 2:
        if((abs(R1 - R1_b) < error) && (abs(R3 - R3_b) < error)) {
          t_comp = (t1 + t3) / 2;
        }
        else if(abs(R1 - R1_b) < error) {
          t_comp = t1;
        }
        else if(abs(R3 - R3_b) < error) {
          t_comp = t3;
        }
        else {
          t_comp = t_raw - (temp - temp_base) * 26.6834;
          if(t_comp < 0) {
            t_comp = 0.0;
          }
        }
        break;
      case 3:
        if((abs(R2 - R2_b) < error) && (abs(R4 - R4_b) < error)) {
          t_comp = (t2 + t4) / 2;
        }
        else if(abs(R2 - R2_b) < error) {
          t_comp = t2;
        }
        else if(abs(R4 - R4_b) < error) {
          t_comp = t4;
        }
        else {
          t_comp = t_raw - (temp - temp_base) * 26.6834;
          if(t_comp < 0) {
            t_comp = 0.0;
          }
        }
        break;
      case 4:
        if((abs(R3 - R3_b) < error) && (abs(R5 - R5_b) < error)) {
          t_comp = (t3 + t5) / 2;
        }
        else if(abs(R3 - R3_b) < error) {
          t_comp = t3;
        }
        else if(abs(R5 - R5_b) < error) {
          t_comp = t5;
        }
        else {
          t_comp = t_raw - (temp - temp_base) * 26.6834;
          if(t_comp < 0) {
            t_comp = 0.0;
          }
        }
        break;
      case 5:
        if((abs(R4 - R4_b) < error) && (abs(R6 - R6_b) < error)) {
          t_comp = (t4 + t6) / 2;
        }
        else if(abs(R4 - R4_b) < error) {
          t_comp = t4;
        }
        else if(abs(R6 - R6_b) < error) {
          t_comp = t6;
        }
        else {
          t_comp = t_raw - (temp - temp_base) * 26.6834;
          if(t_comp < 0) {
            t_comp = 0.0;
          }
        }
        break;
      case 6:
        if((abs(R5 - R5_b) < error) && (abs(R7 - R7_b) < error)) {
          t_comp = (t5 + t7) / 2;
        }
        else if(abs(R5 - R5_b) < error) {
          t_comp = t5;
        }
        else if(abs(R7 - R7_b) < error) {
          t_comp = t7;
        }
        else {
          t_comp = t_raw - (temp - temp_base) * 26.6834;
          if(t_comp < 0) {
            t_comp = 0.0;
          }
        }
        break;
      case 7:
        if((abs(R0 - R0_b) < error) && (abs(R6 - R6_b) < error)) {
          t_comp = (t4 + t6) / 2;
        }
        else if(abs(R0 - R0_b) < error) {
          t_comp = t4;
        }
        else if(abs(R6 - R6_b) < error) {
          t_comp = t6;
        }
        else {
          t_comp = t_raw - (temp - temp_base) * 26.6834;
          if(t_comp < 0) {
            t_comp = 0.0;
          }
        }
        break;
      default:
        // statements
        break;
    }
  }
  return t_comp;
}

int low_alert_test() {
  int count = 0;
  if((R0_b - R0) > 5) {
    count = count + 1;
  }
  if((R1_b - R1) > 5) {
    count = count + 1;
  }
  if((R2_b - R2) > 5) {
    count = count + 1;
  }
  if((R3_b - R3) > 5) {
    count = count + 1;
  }
  if((R4_b - R4) > 5) {
    count = count + 1;
  }
  if((R5_b - R5) > 5) {
    count = count + 1;
  }
  if((R6_b - R6) > 5) {
    count = count + 1;
  }
  if((R7_b - R7) > 5) {
    count = count + 1;
  }
  return count;
}
