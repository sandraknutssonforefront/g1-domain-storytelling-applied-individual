---
description: DDD rules for the domain model. Use when adding or changing code in the Domain project.
applyTo: "TE.DomainStorytellingApplied.Domain/**/*.cs"
---

# DDD Rules

- The Domain project is pure: no infrastructure, UI, persistence or framework dependencies.
- `Reservation` is the aggregate root. Other objects are reached through it; reference other aggregates by id.
- Entities have identity; `Timeslot`, `Premises` identifiers and similar are immutable value objects (`record`/`readonly record struct`).
- Keep invariants inside the model: private setters, factory methods or constructors that validate, no public mutable collections.
- Express the story as behaviour on the model (e.g. `Approve()`, `Reject()`, `RouteForReview()`), not as setters or anemic services.
- Model Reservation state explicitly (e.g. Pending, Approved, Rejected) and reject invalid transitions with a domain exception.
- `BookingPolicy` is a domain object/specification that decides whether a Reservation requires review. No `if` on Booker type spread across the code.
- The System's actions that span objects (check policy, route, notify) go in a domain service or application layer; notifications are a port (interface), not an implementation.
- Raise domain events (e.g. `ReservationApproved`, `ReservationRejected`) instead of calling out directly.
- Folder per concept/aggregate, not per technical type.
