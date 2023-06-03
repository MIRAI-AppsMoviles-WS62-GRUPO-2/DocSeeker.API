namespace DocSeeker.API.Prescriptions.Interfaces.Internal;

// All we offer to another bounded contexts.
// Functions that we want to expose to another bounded contexts.
// We are using Anti-corruption Layer and Facade Pattern.
// This allow us avoid that Bounded Context penetrate into another Bounded Context.
public interface IPrescriptionContextFacade
{
    int TotalPrescriptions();
}