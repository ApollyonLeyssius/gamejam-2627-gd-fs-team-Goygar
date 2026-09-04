void setup() {
  Serial.begin(9600);
}
 
void loop() {
  int x = analogRead(A0);
  int y = analogRead(A3);
 
  // Center is roughly 512
  if (y < 400) {
    Serial.println("W");
  }
  else if (y > 600) {
    Serial.println("S");
  }
  else if (x < 400) {
    Serial.println("A");
  }
  else if (x > 600) {
    Serial.println("D");
  }
  else {
    Serial.println("CENTER");
  }
 
  delay(100);
}
