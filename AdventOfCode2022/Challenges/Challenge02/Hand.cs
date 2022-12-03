using static AdventOfCode2022.Challenges.Challenge02.Outcome;

namespace AdventOfCode2022.Challenges.Challenge02;

abstract record Hand
{
    public static Hand Rock { get; } = new RockHand();
    public static Hand Paper { get; } = new PaperHand();
    public static Hand Scissors { get; } = new ScissorsHand();

    public static Hand[] AllHands { get; } = { Rock, Paper, Scissors };


    public Points Points { get; }

    private Hand(int points) => Points = new Points(points);


    public abstract Outcome Compare(Hand other);

    
    private sealed record RockHand : Hand { public RockHand() : base(1) { }

        public override Outcome Compare(Hand other) => other switch
        {
            RockHand => Draw,
            PaperHand => Loss,
            ScissorsHand => Win
        };
    }
    private sealed record PaperHand : Hand { public PaperHand() : base(2) { }

        public override Outcome Compare(Hand other) => other switch
        {
            PaperHand => Draw,
            RockHand => Win,
            ScissorsHand => Loss
        };

    }
    private sealed record ScissorsHand : Hand { public ScissorsHand() : base(3) { }

        public override Outcome Compare(Hand other) => other switch
        {
            ScissorsHand => Draw,
            PaperHand => Win,
            RockHand => Loss
        };
    }
}
