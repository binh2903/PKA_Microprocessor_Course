#include <16F887.h>
#fuses HS, NOWDT, NOPROTECT, NOLVP
#use delay(clock=4000000) 

// M?ng ch?a gi� tr? BCD (0-9)
unsigned char digits[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

// H�m hi?n th? s? tr�n LED 7 do?n
void display_number(unsigned long number) {
    unsigned char digit_select[6] = {0x01, 0x02, 0x04, 0x08, 0x10, 0x20}; // K�ch ho?t ch�n ch?n digit
    unsigned char i, current_digit;

    for (i = 0; i < 6; i++) {
        // L?y t?ng ch? s? (b?t d?u t? h�ng don v?)
        current_digit = number % 10;
        number /= 10;

        // G?i gi� tr? BCD cho IC 7447 qua PORTC
        output_c(digits[current_digit]);

        // K�ch ho?t digit tuong ?ng qua PORTB
        output_b(digit_select[i]);

        // Th?i gian hi?n th? (Multiplexing delay)
        delay_ms(2);

        // T?t t?t c? c�c digit (tr�nh hi?n th? tr�ng l?p)
        output_b(0x00);
    }
}

void main() {
    unsigned long number = 1;    // Gi� tr? ban d?u hi?n th?
    unsigned long limit = 999999; // Gi?i h?n s? l?n nh?t
    unsigned char ledState = 0xFF; // Tr?ng th�i ban d?u c?a c�c LED d?c l?p (t?t c? b?t)

    // C?u h�nh hu?ng c�c ch�n I/O
    set_tris_c(0xF0); // RC<3:0> l� output (g?i d? li?u t?i IC 7447)
    set_tris_b(0xC0); // RB<5:0> l� output (ch?n digit)
    set_tris_d(0x00); // RD<7:0> l� output (di?u khi?n LED d?c l?p)

    // Kh?i t?o c�c PORT
    output_c(0x00); // PORTC: c�c do?n LED ban d?u t?t
    output_b(0x00); // PORTB: kh�ng k�ch ho?t digit n�o
    output_d(0xFF); // B?t t?t c? LED d?c l?p l�c d?u

    while (TRUE) {
        for (number = 1; number <= limit; number++) {
            unsigned int refresh_count = 50; // S? l?n refresh cho m?i s? (d?m b?o ?n d?nh hi?n th?)
            while (refresh_count--) {
                display_number(number); // Hi?n th? s? hi?n t?i tr�n LED 7 do?n
            }

            // Nh?p nh�y LED d?c l?p tr�n PORTD
            ledState = ~ledState;   // �?o tr?ng th�i c?a c�c LED
            output_d(ledState);     // Xu?t tr?ng th�i m?i ra PORTD
            delay_ms(500);          // Nh?p nh�y LED m?i 500ms
        }
    }
}

