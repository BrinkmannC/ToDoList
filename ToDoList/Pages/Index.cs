using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace ToDoList.Pages
{
    public partial class Index
    {
        public string Title { get; set; } = string.Empty;
        
        public string Discription { get; set; } = string.Empty;
       
        public bool IsCompleted { get; set; }
        string searchTerm { get; set; } = string.Empty;
        
        List<ToDo> toDos = new List<ToDo>();
        List<ToDo> filteredData = new List<ToDo>();
       
        protected override void OnInitialized()
        {
            base.OnInitialized();
            TitleTest();
            filteredData = toDos;
           
        }

        private void OnButtonClick()
        {
            ToDo todo = new ToDo();
            todo.Title = Title;
            todo.Discription = Discription;
            if (Title != string.Empty && Discription != string.Empty) 
            {
                filteredData.Add(todo);
                Title = string.Empty;
                Discription = string.Empty;
            }
        }
        private void SearchOnKeyUp(KeyboardEventArgs e)
        {
             // Aktualisiere searchTerm mit dem aktuellen Wert des Eingabefelds.
            Search();
        }
        private void Search()
        {
            filteredData = toDos.Where(item =>
            item.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            item.Discription.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        private void TitleTest()
        {
            ToDo toDo = new ToDo();
            toDo.Title = "Einkaufen";
            toDo.Discription = "Milch, Eier, Brot kaufen";
            toDo.IsCompleted = false;
            toDos.Add(toDo);
        }
    }
    // Modellklasse
    public class ToDo
    {   
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "Title is too long")]
        public string Discription { get; set; } = string.Empty;
        [Required]
        [StringLength(250, ErrorMessage = "Discription is too long")]
        public bool IsCompleted { get; set; }
    }

}
