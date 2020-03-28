using Microsoft.AspNetCore.Mvc;
using Organizer.Application.Providers;

namespace Organizer.Application.ViewModels
{
    public class BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Permalink { get; set; }
        [FromCookie(Name = "Lang")] 
        public virtual string Lang { get; set; } = "tr-TR";
    }
}