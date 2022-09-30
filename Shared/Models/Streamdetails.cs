namespace MovieManager.Shared.Models
{
    public partial class Streamdetails
    {
        public int? IdFile { get; set; }
        public int? IStreamType { get; set; }
        public string StrVideoCodec { get; set; }
        public float? FVideoAspect { get; set; }
        public int? IVideoWidth { get; set; }
        public int? IVideoHeight { get; set; }
        public string StrAudioCodec { get; set; }
        public int? IAudioChannels { get; set; }
        public string StrAudioLanguage { get; set; }
        public string StrSubtitleLanguage { get; set; }
        public int? IVideoDuration { get; set; }
        public string StrStereoMode { get; set; }
        public string StrVideoLanguage { get; set; }
    }
}
