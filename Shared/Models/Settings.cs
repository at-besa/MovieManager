namespace MovieManager.Shared.Models
{
    public partial class Settings
    {
        public int? IdFile { get; set; }
        public bool? Deinterlace { get; set; }
        public int? ViewMode { get; set; }
        public float? ZoomAmount { get; set; }
        public float? PixelRatio { get; set; }
        public float? VerticalShift { get; set; }
        public int? AudioStream { get; set; }
        public int? SubtitleStream { get; set; }
        public float? SubtitleDelay { get; set; }
        public bool? SubtitlesOn { get; set; }
        public float? Brightness { get; set; }
        public float? Contrast { get; set; }
        public float? Gamma { get; set; }
        public float? VolumeAmplification { get; set; }
        public float? AudioDelay { get; set; }
        public int? ResumeTime { get; set; }
        public float? Sharpness { get; set; }
        public float? NoiseReduction { get; set; }
        public bool? NonLinStretch { get; set; }
        public bool? PostProcess { get; set; }
        public int? ScalingMethod { get; set; }
        public int? DeinterlaceMode { get; set; }
        public int? StereoMode { get; set; }
        public bool? StereoInvert { get; set; }
        public int? VideoStream { get; set; }
        public int? TonemapMethod { get; set; }
        public float? TonemapParam { get; set; }
        public int? Orientation { get; set; }
        public int? CenterMixLevel { get; set; }
    }
}
