using System.Collections.Generic;

public class BookComparator : IComparer<Book>
    {
        public int Compare(Book A, Book B)
        {
            int result = A.Title.CompareTo(B.Title);

            if(result == 0)
            {
                result = B.Year.CompareTo(A.Year);
            }

            return result;
        }
    }
