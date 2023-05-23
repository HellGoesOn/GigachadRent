using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GigachadRent
{
    public partial class TemplateForm : Form
    {
        public TemplateForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (Owner as EquipmentForm).GetJuictyText("Грейдер",
                @"Вес и грузоподъемность: вес X тонн, грузоподъемность X
Мощность двигателя: X кВт
Ширина отвала: от X до X метров
Глубина проникновения отвала: от X до X метров; 
Скорость передвижения: X км/ч
");
            this.Close();
        }

        private void TemplateForm_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (Owner as EquipmentForm).GetJuictyText("Погрузчик",
                @"Грузоподъемность: X кг
Мощность двигателя: X л.с.
Объем ковша: X м³
Максимальная скорость: X км/ч
Вес погрузчика: X кг
");
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (Owner as EquipmentForm).GetJuictyText("Кран",
                @"Грузоподъемность: X тонн
Максимальная высота подъема: X метров
Длина стрелы: X метров
Мощность двигателя: X л.с.
Вес крана: X кг
");
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (Owner as EquipmentForm).GetJuictyText("Автобетононасос",
                @"Максимальная дальность подачи бетона: 0 метра
Грузоподъемность: 0 м3/час
Диаметр цилиндра насоса: 0 мм
Максимальное давление на выходе: 0 бар
Вес автобетононасоса: 0 кг
");
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            (Owner as EquipmentForm).GetJuictyText("Каток",
                @"Вибрационный каток с двумя барабанами
Мощность двигателя: 0 л.с.
Рабочая ширина: 0 мм
Вес: 0 тонны
Высокая проходимость благодаря большому дорожному просвету и гусеничной подвеске.
");
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            (Owner as EquipmentForm).GetJuictyText("Автовышка",
                @"Максимальная высота подъема: 0 метров
Максимальная горизонтальная вылетаемость: 0 метра
Грузоподъемность корзины: 0 кг
Время развертывания: 0 минут
Система управления с помощью джойстика и пульта управления на корзине.
");
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            (Owner as EquipmentForm).GetJuictyText("Бетономеситель",
                  @"Объем барабана: 0 куб.м
Максимальная производительность: 0 куб.м / час
Система управления: автоматическая
Вес: 0 тонн
");
            this.Close();
        }
    }
}
