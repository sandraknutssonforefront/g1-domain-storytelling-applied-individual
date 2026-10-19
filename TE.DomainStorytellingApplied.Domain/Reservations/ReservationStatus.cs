namespace TE.DomainStorytellingApplied.Domain.Reservations;

public enum ReservationStatus
{
    Requested = 0,
    PendingReview,
    Approved,
    Rejected,
}
