#include <16F887.h>
#fuses HS, NOWDT, NOLVP, PUT
#use delay(clock=20000000) // Th?ch anh 20MHz

// Mã hi?n th? cho LED 7 do?n Common Anode (các s? t? 1 d?n 9)
const int8 led_7segment[] = {
   0b11111001, // S? 1
   0b10100100, // S? 2
   0b10110000, // S? 3
   0b10011001, // S? 4
   0b10010010, // S? 5
   0b10000010, // S? 6
   0b11111000, // S? 7
   0b10000000, // S? 8
   0b10010000  // S? 9
};

void main() {
   set_tris_c(0x00); // C?u hình PORTC là ngõ ra
   output_c(0xFF);   // T?t toàn b? LED (Common Anode c?n tín hi?u cao d? t?t)
   
   while(TRUE) {
      for (int i = 0; i < 9; i++) { // Hi?n th? t? 1 d?n 9
         output_c(led_7segment[i]); // Xu?t giá tr? tuong ?ng t? m?ng ra PORTC
         delay_ms(1000);           // Delay 1 giây
      }
   }
}

