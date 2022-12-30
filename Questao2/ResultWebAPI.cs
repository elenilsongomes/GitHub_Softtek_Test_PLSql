namespace Questao2
{
    public class ResultWebAPI
    {
        private int page = 0;
        private int per_page = 0;
        private int total = 0;
        private int total_pages = 0;
        private IList<ResultWebAPIData> data = new List<ResultWebAPIData>();

        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        public int Per_page
        {
            get { return per_page; }
            set { per_page = value; }
        }

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        public int Total_pages
        {
            get { return total_pages; }
            set { total_pages = value; }
        }

        public IList<ResultWebAPIData> Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
