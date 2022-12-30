namespace Questao2
{
    public class ResultWebAPIData
    {
        private string competition = string.Empty;
        private int year = 0;
        private string round = string.Empty;
        private string team1 = string.Empty;
        private string team2 = string.Empty;
        private int team1goals = 0;
        private int team2goals = 0;

        public string Competition
        { 
            get { return competition; }
            set { competition = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Round
        {
            get { return round; }
            set { round = value; }
        }

        public string Team1
        {
            get { return team1; }
            set { team1 = value; }
        }

        public string Team2
        {
            get { return team2; }
            set { team2 = value; }
        }

        public int Team1goals
        {
            get { return team1goals; }
            set { team1goals = value; }
        }

        public int Team2goals
        {
            get { return team2goals; }
            set { team2goals = value; }
        }
    }
}
