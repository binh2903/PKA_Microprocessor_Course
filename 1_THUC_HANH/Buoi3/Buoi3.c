#include <16F887.h>
#fuses HS, NOWDT, NOPROTECT, NOLVP
#use delay(clock=4000000) 

// M?ng ch?a giá tr? BCD (0-9)
unsigned char digits[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

// Hàm hi?n th? s? trên LED 7 do?n
void display_number(unsigned long number) {
    unsigned char digit_select[6] = {0x01, 0x02, 0x04, 0x08, 0x10, 0x20}; // Kích ho?t chân ch?n digit
    unsigned char i, current_digit;

    for (i = 0; i < 6; i++) {
        // L?y t?ng ch? s? (b?t d?u t? hàng don v?)
        current_digit = number % 10;
        number /= 10;

        // G?i giá tr? BCD cho IC 7447 qua PORTC
        output_c(digits[current_digit]);

        // Kích ho?t digit tuong ?ng qua PORTB
        output_b(digit_select[i]);

        // Th?i gian hi?n th? (Multiplexing delay)
        delay_ms(2);

        // T?t t?t c? các digit (tránh hi?n th? trùng l?p)
        output_b(0x00);
    }
}

void main() {
    unsigned long number = 1;    // Giá tr? ban d?u hi?n th?
    unsigned long limit = 999999; // Gi?i h?n s? l?n nh?t
    unsigned char ledState = 0xFF; // Tr?ng thái ban d?u c?a các LED d?c l?p (t?t c? b?t)

    // C?u hình hu?ng các chân I/O
    set_tris_c(0xF0); // RC<3:0> là output (g?i d? li?u t?i IC 7447)
    set_tris_b(0xC0); // RB<5:0> là output (ch?n digit)
    set_tris_d(0x00); // RD<7:0> là output (di?u khi?n LED d?c l?p)

    // Kh?i t?o các PORT
    output_c(0x00); // PORTC: các do?n LED ban d?u t?t
    output_b(0x00); // PORTB: không kích ho?t digit nào
    output_d(0xFF); // B?t t?t c? LED d?c l?p lúc d?u

    while (TRUE) {
        for (number = 1; number <= limit; number++) {
            unsigned int refresh_count = 50; // S? l?n refresh cho m?i s? (d?m b?o ?n d?nh hi?n th?)
            while (refresh_count--) {
                display_number(number); // Hi?n th? s? hi?n t?i trên LED 7 do?n
            }

            // Nh?p nháy LED d?c l?p trên PORTD
            ledState = ~ledState;   // Ð?o tr?ng thái c?a các LED
            output_d(ledState);     // Xu?t tr?ng thái m?i ra PORTD
            delay_ms(500);          // Nh?p nháy LED m?i 500ms
        }
    }
}

