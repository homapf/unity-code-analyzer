using System;

namespace HomaGames.CodeAnalyzer.Tests
{
    public class MyAwesomeAPICalls
    {
        public MyAwesomeAPICalls()
        {
            MyAwesomeAPI api = new MyAwesomeAPI();
            api.MyAwesomeMethod();
        }
        
        public int ThatProperty
        {
            get
            {
                MyAwesomeAPI api = new MyAwesomeAPI();
                api.MyAwesomeMethod();
                return default;
            }
            set
            {
                MyAwesomeAPI api = new MyAwesomeAPI();
                api.MyAwesomeMethod();
            }
        }

        public void ThatMethodName()
        {
            MyAwesomeAPI api = new MyAwesomeAPI();
            api.MyAwesomeMethod();
        }
        
        public void LambdaCalls()
        {
            var lambda = new Action(() =>
            {
                MyAwesomeAPI api = new MyAwesomeAPI();
                api.MyAwesomeMethod();
                var nestedLambda = new Action(() =>
                {
                    api.MyAwesomeMethod();
                });
            });
        }
    }
}