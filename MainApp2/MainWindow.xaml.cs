using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using LibMas;
using Lib_2;


namespace MainApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[] mas;

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();//выход из программы
        }

        private void info_Click(object sender, RoutedEventArgs e)//информация
        {
            MessageBox.Show("Ермолаев Дмитрий ИСП-31 Вариант 9 Ввести n целых чисел(>0 или <0). Найти произведение чисел. Результат вывести на экран");
        }

        private void Tablitsa_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //ввод описание
            //одномерный
            int indexColumn = e.Column.DisplayIndex;
            int indexRow = e.Row.GetIndex();
            mas[indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }

        private void Go_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Diap.Text.Length; i++)
            {
                if (Diap.Text[i] == ' ')
                {
                    MessageBox.Show("Некоректное значение!");
                    Diap.Text = null;
                    return;
                }
            }
                                                                 //защита от некор. значений
            for (int i = 0; i < Yach.Text.Length; i++)
            {
                if (Yach.Text[i] == ' ')
                {
                    MessageBox.Show("Некоректное значение!");
                    Yach.Text = null;
                    return;
                }
            }

            //предел таблицы
            int Count = Convert.ToInt32(Yach.Text);
            mas = new int[Count];
            Tablitsa.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;

            //предел по строкам
            int randMax = Convert.ToInt32(Diap.Text);

            //количество ячеек
            Count = Convert.ToInt32(Yach.Text);

            mas = new int[Count];//создание массива

            ClassMas.InflateMas(Count, randMax, out mas);//использование функции заполнения

            Tablitsa.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;//вывод на таблицу            
        }


        private void Rasch_Click(object sender, RoutedEventArgs e)//расчет произведения
        {
            int rez;//результат
            rez = Class2.YmnozhMas(mas);//функция умножения всех элементов массива
            Rez.Text = Convert.ToString(rez);//вывод
        }

        private void Clear_Click(object sender, RoutedEventArgs e)//очистка
        {
            ClassMas.ClearMas(mas, out mas);//функция очистки
            Tablitsa.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;//вывод на таблицу
        }

        private void Diap_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.Text, 0));    //блокировка ввода некор.знач
        }

        private void Yach_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.Text, 0));     //блокировка ввода некор.знач
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            //настраиваем элемент открыть
            OpenFileDialog open = new OpenFileDialog();

            open.DefaultExt = ".txt";
            open.Filter = "Bce файлы (*.*) | *.* | текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            //открытие окна
            if (open.ShowDialog() == true)
            {

                //создание потока
                StreamReader file = new StreamReader(open.FileName);

                //определение размера
                int len = Convert.ToInt32(file.ReadLine());

                //ввод массива
                mas = new Int32[len];

                //распаковка из файла
                for (int i = 0; i < mas.Length; i++)

                {

                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();

                //вывод
                Tablitsa.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            //настройка элемента сохранить
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение ряда";

            //открытие окна
            if (save.ShowDialog() == true)

            {
                //создание потока
                StreamWriter file = new StreamWriter(save.FileName);
                //записываем размер массива в файл
                file.WriteLine(mas.Length);
                //запись в файл
                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
                file.Close();
            }
        }
    }
}
