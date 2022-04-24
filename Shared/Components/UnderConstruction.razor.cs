using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Models;
using ZwiepsHaakHoek.Services.Interpreter;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class UnderConstruction
    {
        [Inject]
        public IInterpreter Interpreter { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public Image BackgroundImage { get; set; }

        protected override void OnInitialized()
        {
            BackgroundImage ??= new Image
            {
                Url = "https://th.bing.com/th/id/R.c1e403d15877de14c24d10124926fa3e?rik=aekqd8ed1YMpTg&riu=http%3a%2f%2f3.bp.blogspot.com%2f-OKeLxLWEWpo%2fVUYmKvu3ySI%2fAAAAAAAAA4M%2fIUuX8eVBlwU%2fw1200-h630-p-k-no-nu%2fSAM_5358ed.jpg&ehk=O%2bjyUBvhiRLfq9WkAKySOlcHiCTG8v84pN2oVG5t8aw%3d&risl=&pid=ImgRaw&r=0",
                Alt = Interpreter["WorkInProgress"]
            };

            base.OnInitialized();
        }
    }
}
