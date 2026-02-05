using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Module4Challenge.Pages
{
    public class IndexModel : PageModel
    {
        //ccreate public bool ShowResults initialized to false
        public bool ShowResults {get; set;} = false;
        //create a public empty array of size of the SelectorSize to transfer selected jokes into
        public string[] SmallSelectedJokes {get; set;}= new string[SelectorSize];
        //create a public empty array equal to the SelectorSize to track which values have been chosen by the selector
        public string[] LargeSelectedJokes {get; set;}= new string[SelectorSize + ArrayResize];
        //define public array DadJokes initialized with 12 jokes
        public string[] DadJokes = new string[12]
         {"Did I ever tell you about the time I went mushroom foraging? It's a story with a morel at the end.",
            "I had a quiet game of tennis today. There was no racket.",
            "Why did the electric car feel discriminated against? Because the rules weren't current.",
            "What's the best way to save your dad jokes? In a dadda-base.",
            "I went to the aquarium this weekend, but I didn't stay long. There's something fishy about that place.",
            "How is my wallet like an onion? Every time I open it, I cry.",
            "What do you call a dog who meditates? Aware wolf.",
            "What's the hardest tea to swallow? Reality.",
            "Never date a tennis player. Love means nothing to them.",
            "I threw a boomerang months ago. Now I live in constant fear.",
            "Dogs can't operate MRI machines. But catscan.",
            "Why can't dinosaurs clap their hands? Because they're extinct."
            };
        //create static int SelectorSize which controls the size of SelectedJokes and SelectedValues
        static int SelectorSize = 3;
        //create static int array Resize which controls the resize between small and large selected jokes
        static int ArrayResize = 3;
        public int[] SelectedValues = new int[SelectorSize];
        public void OnGet()
        {
            //create new random object and selector int
            Random random = new Random();
            int selector;
            // for each value from i = 0 to the length of SelectedJokes assign SelectedValues at location[i]
            // a joke from DadJokes at location chosen by selector
            for (int i = 0; i < SmallSelectedJokes.Length; i++)
            {
                //set selector to a random value between 0 and the len of DadJokes if that value is in the SelectedValues 
                //array repeat untill a unique value is found
                do
                {
                    selector = random.Next(0, DadJokes.Length);
                } while (SelectedValues.Contains(selector));

                SelectedValues[i] = selector;
                SmallSelectedJokes[i] = DadJokes[selector];
            }
                

        }
        public void OnPost()
        {
            // flip ShowResults bool to true 
            ShowResults = true;
            //Resize Array of SelectedValues maintaining the first values
            Array.Resize(ref SelectedValues, SelectorSize + ArrayResize);
            //Define new random object and selector
            Random random = new Random();
            int selector;
            // for each value from i = 0 to the Length of LargeSelectedJokes assign Large SelectedJokes at locatio[i] a value from DadJokes at the point of the selector
            // append selected value to the SelectedValues array to avoid duplicates
            for (int i = 0; i < LargeSelectedJokes.Length; i++)
            {
                //set selector to a random value between 0 and the len of DadJokes if that value is in the SelectedValues 
                //array repeat untill a unique value is found
                do
                {
                    selector = random.Next(0, DadJokes.Length);
                } while (SelectedValues.Contains(selector));

                SelectedValues[i] = selector;
                LargeSelectedJokes[i] = DadJokes[selector];
            }

        }
    }
}