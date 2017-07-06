using System;
using System.Text;

namespace _02.Book_Shop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual string Title { get { return this.title; }
        set
            {
                if(value.Length <= 3)
                {
                    throw new ArgumentException(ExceptionMessages.TitleNotValid);
                }
                this.title = value;
            }
        }

        public virtual string Author { get { return this.author; }
        set
            {
                var names = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (names.Length == 2 && char.IsDigit(names[1][0]))
                {
                    throw new ArgumentException(ExceptionMessages.AuthorNotValid);
                }
                this.author = value;
            }
        }

        public virtual decimal Price { get { return this.price; }
        set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PriceNotValid);
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Type: ").AppendLine(this.GetType().Name)
              .Append("Title: ").AppendLine(this.Title)
              .Append("Author: ").AppendLine(this.Author)
              .Append("Price: ").Append($"{this.Price:F1}")
              .AppendLine();

            return sb.ToString();
        }
    }
}
