using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_Homework
{
    class Computer
    {
        //Модель  компьютера  характеризуется:

        //код
        public string Id { get; set; }
        //название марки компьютера
        public string Name { get; set; }
        //тип процессора
        public string Cpu { get; set; }
        //частота работы процессора МГц
        public int FqCpu { get; set; }
        //объем оперативной памяти ГБ
        public int Ram { get; set; }
        //объем жесткого диска Гб
        public int Hd { get; set; }
        //объем памяти видеокарты Гб
        public int Vc { get; set; }
        //стоимость компьютера тыс. руб.
        public decimal Price { get; set; }
        //количество экземпляров, имеющихся в наличии
        public int Number { get; set; }

    }
}
