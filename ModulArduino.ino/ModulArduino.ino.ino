int VRx_1 = A0;
int VRy_1 = A1;

int PB_1 = 8;
int PB_2 = 9;
int PB_3 = 10;
int PB_4 = 11;

unsigned long prevMillis = 0;
int msDelay = 20;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(19200);
 
  pinMode(VRx_1, INPUT);
  pinMode(VRy_1, INPUT);
  
  pinMode(PB_1, INPUT_PULLUP);
  pinMode(PB_2, INPUT_PULLUP);
  pinMode(PB_3, INPUT_PULLUP);
  pinMode(PB_4, INPUT_PULLUP);
}

void loop() {
  // put your main code here, to run repeatedly:
  unsigned long currentMillis = millis();
  if(currentMillis - prevMillis > msDelay){
    inputLoop();
    
    prevMillis = currentMillis;
  }
}

// fungsi yang dijalankan berulang kali
void inputLoop() {
  //membaca perubahan data dari joystick 1
  int xPosition_1 = analogRead(VRx_1);
  int yPosition_1 = analogRead(VRy_1);

  int mapX_1 = map(xPosition_1, 1, 1024, -5, 5);
  int mapY_1 = map(yPosition_1, 1, 1024, -5, 5);

  if (mapX_1 > 0)
    mapX_1 = 1;
  if (mapY_1 > 0)
    mapY_1 = 1;

  if (mapX_1 < 0)
    mapX_1 = 1;
  if (mapY_1 < 0)
    mapY_1 = 1;

  //membaca perubahan data dari pushbutton
  int PB_state_1 = digitalRead(PB_1);
  int PB_state_2 = digitalRead(PB_2);
  int PB_state_3 = digitalRead(PB_3);
  int PB_state_4 = digitalRead(PB_4);
  
  //mencetak perubahan data yang terjadi
  //joystick-1
  Serial.print(mapX_1);
  Serial.print(",");
  //Serial.print(mapY_1);
  //Serial.print(",");

  //pushbutton
  Serial.print(PB_state_1);
  Serial.print(",");
  Serial.print(PB_state_2);
  Serial.print(",");
  Serial.println(PB_state_3);
  //Serial.print(",");
  //Serial.println(PB_state_4);
}
