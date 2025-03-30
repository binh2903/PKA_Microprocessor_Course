#include <16F887.h>
#fuses HS, NOWDT, NOPROTECT, NOBROWNOUT, NOLVP, NOPUT, NOWRT, NODEBUG, NOCPD
#use delay(clock = 20000000)
#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7, bits=8)  // UART TX: C6, RX: C7

#include <lcd.c>

#define DT1 PIN_C0
#define SCK PIN_C1
//#define TARE_BUTTON PIN_C2   // Không dùng nút chuy?n don v?

#define use_portb_lcd TRUE

// Thông s? Scale, tùy ch?nh theo cân/HX711 c?a b?n
double SCALE = 36.0 * 25.595;  

// Bi?n toàn c?c
volatile float weight = 0.0;
volatile int16 count_ms = 0;

// Ng?t Timer1 (m?i kho?ng 20ms)
#INT_TIMER1
void timer1_isr()
{
    // V?i T1_DIV_BY_2, 20MHz: 65536 - 5000 = 60536 cho kho?ng 20ms
    set_timer1(60536);
    count_ms++;
}

// Ð?c d? li?u RAW t? HX711 (24 bit)
unsigned int32 readCount(void)
{
    unsigned int32 data = 0;
    unsigned int8 j;

    output_bit(DT1, 1);
    output_bit(SCK, 0);
    while (input(DT1));  // Ch? Data xu?ng m?c th?p (HX711 s?n sàng)

    for (j = 0; j < 24; j++)
    {
        output_bit(SCK, 1);
        data = data << 1;
        output_bit(SCK, 0);
        if (input(DT1))
        {
            data++;
        }
    }

    // L?n clock th? 25: d?c bit gain/channel (m?c d?nh 128)
    output_bit(SCK, 1);
    data = data ^ 0x800000;  // Ð?o bit d?u (bit 24)
    output_bit(SCK, 0);

    return data;
}

// Ð?c trung bình n l?n d? gi?m nhi?u
int32 readAverage(void)
{
    unsigned int32 sum = 0;
    int k;
    for(k = 0; k < 3; k++)
    {
        sum += readCount();
    }
    return (sum / 3);
}

void main(void)
{
    unsigned int32 offset, read1;

    // Kh?i t?o LCD và hi?n th? thông báo ban d?u
    lcd_init();
    lcd_putc("HX711 Scale");
    delay_ms(500);

    // C?u hình Timer1: s? d?ng n?i b? v?i chia t?n s? /2
    setup_timer_1(T1_INTERNAL | T1_DIV_BY_2);
    set_timer1(60536);
    enable_interrupts(INT_TIMER1);
    enable_interrupts(GLOBAL);

    // Ð?c offset ban d?u (tr?ng thái không t?i)
    offset = readAverage();

    while(TRUE)
    {
        // M?i 20ms th?c hi?n d?c cân 1 l?n
        if (count_ms >= 20)
        {
            count_ms = 0;
            read1 = readAverage();

            // Tính tr?ng lu?ng (don v? gam)
            if (offset >= read1)
            {
                weight = (float)(offset - read1) / SCALE;
                if (weight < 1) weight = 0;  // Ngu?ng nh? thì coi nhu 0
            }
            else
            {
                weight = (float)(read1 - offset) / SCALE;
                if (weight < 1) weight = 0;
            }

            // Hi?n th? lên LCD
            lcd_putc("\fWeight:");
            printf(lcd_putc, "\n%.2f g", weight);

            // G?i d? li?u qua UART (m?i dòng: "xx.xx\r\n")
            printf("%.2f\r\n", weight);

            delay_ms(5);
        }
    }
}

