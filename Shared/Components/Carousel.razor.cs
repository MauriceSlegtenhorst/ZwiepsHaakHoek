using Microsoft.AspNetCore.Components;
using System.Timers;
using ZwiepsHaakHoek.Models.Carousel;

using Timer = System.Timers.Timer;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class Carousel : IDisposable
    {
        private Timer _timer;

        private int _index;

        private string _imageCSS;

        private CarouselImage[] _images;
        [Parameter, EditorRequired]
        public Func<CarouselImage[]> Images { get; set; }

        /// <summary>
        /// Interval in miliseconds. Changes to the next image every interval.
        /// </summary>
        [Parameter]
        public double? Interval { get; set; }

        [Parameter, EditorRequired]
        public int MaxPixelHeight { get; set; }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Elapsed -= Tick;
                _timer.Dispose();
            }
        }

        protected override Task OnInitializedAsync()
        {
            if (Interval.HasValue)
            {
                _timer = new Timer(Interval.Value);
                _timer.Elapsed += Tick;
                _timer.Enabled = true;
                _timer.Start();
            }

            _images = Images.Invoke();

            return base.OnInitializedAsync();
        }

        private void MoveNext()
        {
            _index = _index == _images.Length - 1
                    ? 0
                    : _index + 1;
        }

        private void MovePrevious()
        {
            _index = _index == 0
                    ? _images.Length - 1
                    : _index - 1;
        }

        private void Tick(object s, ElapsedEventArgs e)
        {
            MoveNext();
            StateHasChanged();
        }
    }
}
