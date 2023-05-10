using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainNotebookProject.Backroll;
using Newtonsoft.Json;

namespace MainNotebookProject
{
    /// <summary>
    /// Логика взаимодействия для NoteEditro.xaml
    /// </summary>
    public partial class NoteEditro : Window
    {
        Note currentMessage; // переданная ссылка на заметку которую выбрали и открыли с маинменю в ноутедитор 
        Сensurer c;

        public NoteEditro(object a) // 
        {
            InitializeComponent();

            currentMessage = (Note)a; // берём при открытие окошка

            LoadNote();
        }

        void LoadNote()
        {
            Title = currentMessage.ToString();
            if (currentMessage.IsText) { tb1.Text = currentMessage.Value==null?"":currentMessage.Value.ToString(); }
            //else { ic1 = (InkCanvas)currentMessage.Value; }
            //else { ic1 = currentMessage.Value == null ? ic1 : JsonConvert.DeserializeObject((string)currentMessage.Value) as InkCanvas; }
            else if(currentMessage.Value != null) ic1.Strokes = (StrokeCollection)currentMessage.Value;
        }

        private void WhatItsHappend(Note a) // изменение заметки, !\то с чем работаем - то, что мы видим\!
        {
            if (a.IsText)
            {

                a.Value = tb1.Text; // если текст 
            }
            else
            {
                //a.Value = ic1; // если инкканвас
                //a.Value = JsonConvert.SerializeObject(ic1, new JsonSerializerSettings(){ ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                a.Value = ic1.Strokes;
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e) // save button сохранение кнопка 
        {
            WhatItsHappend((Note)this.currentMessage);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //currentMessage = null;
        }
    }
}
