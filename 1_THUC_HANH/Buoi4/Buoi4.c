#include <16F887.h>
#fuses HS, NOWDT, NOPROTECT, NOLVP
#use delay(clock=4MHz)

int8 time[3] = {0, 0, 0}; // {hour, minute, second}
int8 current_digit = 0;

// Ch?n s? LED tuong ?ng qua 7447
void select_digit(int8 pos) {
    output_b(1 << pos);  // Chuy?n qua LED tuong ?ng (RB0-RB5)
}

// Xu?t m� BCD t?i 7447
void display_digit(int8 value) {
    output_a(value & 0x0F); // Ch? xu?t 4 bit th?p ph�n (BCD)
}

#INT_TIMER1
void clock_isr() {
    static int16 count = 0;
    count++;
    if (count >= 50000) { // 1 gi�y v?i th?ch anh 4 MHz, prescaler 8
        count = 0;
        time[2]++;  // Tang gi�y
        if (time[2] >= 60) {
            time[2] = 0;
            time[1]++; // Tang ph�t
            if (time[1] >= 60) {
                time[1] = 0;
                time[0]++; // Tang gi?
                if (time[0] >= 24) {
                    time[0] = 0; // Reset gi? khi > 23
                }
            }
        }
    }
}

void display_time() {
    int8 digits[6];
    digits[0] = time[0] / 10; // Gi? h�ng ch?c
    digits[1] = time[0] % 10; // Gi? h�ng don
    digits[2] = time[1] / 10; // Ph�t h�ng ch?c
    digits[3] = time[1] % 10; // Ph�t h�ng don
    digits[4] = time[2] / 10; // Gi�y h�ng ch?c
    digits[5] = time[2] % 10; // Gi�y h�ng don

    select_digit(current_digit);   // Ch?n LED tuong ?ng
    display_digit(digits[current_digit]); // Xu?t m� BCD cho 7447

    current_digit = (current_digit + 1) % 6; // Chuy?n qua LED ti?p theo
}

void main() {
    setup_timer_1(T1_INTERNAL | T1_DIV_BY_8); // Prescaler chia 8
    enable_interrupts(INT_TIMER1);
    enable_interrupts(GLOBAL);

    set_tris_a(0xF0); // RA0 - RA3 l� output cho BCD d? li?u t?i 7447
    set_tris_b(0xC0); // RB0 - RB5 l� output (ch?n LED)

    while(TRUE) {
        display_time();
        delay_ms(2); // Qu�t LED
    }
}
