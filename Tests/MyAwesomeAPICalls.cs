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
            MyAwesomeAPI api = new MyAwesomeAPI();
            var lambda = new Action(() =>
            {
                api.MyAwesomeMethod();
                var nestedLambda = new Action(() =>
                {
                    api.MyAwesomeMethod();
                });
                nestedLambda.Invoke(); // avoid stripping
            });
            lambda.Invoke(); // avoid lambda stripping
        }
    }
}