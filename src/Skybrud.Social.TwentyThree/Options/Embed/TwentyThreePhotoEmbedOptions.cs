#pragma warning disable CS1591

namespace Skybrud.Social.TwentyThree.Options.Embed {

    public class TwentyThreePhotoEmbedOptions {

        public string Domain { get; set; }

        public string PhotoId { get; set; }

        public string Token { get; set; }

        public string PlayerId { get; set; }

        public bool? AutoPlay { get; set; }

        public TwentyThreePhotoEmbedEndOn? EndOn { get; set; }

    }

}