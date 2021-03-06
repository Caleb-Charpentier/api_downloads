using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Features.Auth;

namespace WebApplication1.Features.FlashCards
{
    public class FlashCardSet
    {
        
        public int FlashCardSetId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FlashCardId { get; set; }
        public virtual ICollection<FlashCard> flashCard { get; set; } = new List<FlashCard>(); 
        //public virtual User user { get; set; }


    }


}
