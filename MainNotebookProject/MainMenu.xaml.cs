using MainNotebookProject.Backroll;
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
using System.Windows.Shapes;

namespace MainNotebookProject
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        int notesCount = 0; // можно ваще удалить но не сейчас!

        readonly NoteBook notebookie;
        Сensurer notesese;

        public MainMenu()
        {
            InitializeComponent();
            notebookie = new(new List<Note>());
            notesese = new(notebookie);
            //lb1.ItemsSource = notesese.ContentGet();
            

            //Test1(); // врубаем временные заметки
        }

        void Test1() // временные заметки которые мы проверяем на функционал
        {
            // добавление в листбоксик заметки с названием test,
            // значением внутри gsefgsdsfd и датой, а true значит, что заметка текстовая
            Note aa = new Note("test", "gsefgsdsfd", new DateTime(2000, 01, 01, 12, 59, 00), true);
            ListBoxItem a = new() { Content =  aa}; 
                                                                                                                              

            a.MouseDoubleClick += A_MouseDoubleClick; // открытие определенного элемента впф чудит


            lb1.Items.Add(a); // добавляем тестовую заметку в листбоксик 
            //notebookie.notes.Add(aa);
            //lb1.ItemsSource = notebookie.notes;
            notesese.ContentSet(aa);
        }

        private void A_MouseDoubleClick(object sender, MouseButtonEventArgs e) // открытие редактора заметок
        {
            NoteEditro a = new(((ListBoxItem)sender).Content); // заставляет открыть редактор заметок куда чо как почему вот он решает
            a.ShowDialog(); // открываем это окошко редакции 
        }

        private void Button_Add_Item_Click(object sender, RoutedEventArgs e) // добавление новой заметки (на данный момент only testing)
        {
            Note newN; ListBoxItem newI;

            if (MessageBox.Show("paint?", "paint?", MessageBoxButton.YesNo, MessageBoxImage.Question ,MessageBoxResult.None)==MessageBoxResult.Yes)
            {
                notesCount++;

                newN = new() { Name = "picture"+notesCount, Date = DateTime.Now, IsText = false };
                newI = new ListBoxItem() { Content = newN };
                newI.MouseDoubleClick += A_MouseDoubleClick;
                // добавляем всё также как в первой заметке тестовой но тут теперь false, значит упор идёт на рисунки!
                lb1.Items.Add(newI);
                notesese.ContentSet(newN);
            }
            else
            {
                notesCount++;

                newN = new() { Name = "flowDocument"+notesCount, Date = DateTime.Now, IsText=true };
                newI = new ListBoxItem() { Content = newN};
                newI.MouseDoubleClick += A_MouseDoubleClick;
                lb1.Items.Add(newI);
                notesese.ContentSet(newN);
            }
            
        }

        private void lb1_SelectionChanged(object sender, SelectionChangedEventArgs e) // ай ну его не работает
        {
            foreach (ListBoxItem item in ((ListBox)sender).Items)
            {
                //((ListBoxItem)item).MouseDoubleClick += A_MouseDoubleClick(sender, new MouseButtonEventArgs());
                //A_MouseDoubleClick(sender, (MouseButtonEventArgs)e);

                item.MouseDoubleClick += A_MouseDoubleClick; // то же самое что сверху но уже в цикле должно быть!!!!!
            }

        }
    }
}
