

namespace EdGame.Behaviors.AnimationBehavior;

public class BounceBehavior : Behavior<Button>
{
    protected override void OnAttachedTo(Button button)
    {
        base.OnAttachedTo(button);

        // Subscribir el evento Clicked para animar el botón al hacer clic
        button.Clicked += async (sender, args) =>
        {
            await AnimateButton(button);
        };
    }

    protected override void OnDetachingFrom(Button button)
    {
        base.OnDetachingFrom(button);

        // Desuscribir el evento Clicked
        button.Clicked -= async (sender, args) =>
        {
            await AnimateButton(button);
        };
    }

    // Método que ejecuta la animación de rebote
    private async Task AnimateButton(Button button)
    {
        // Realiza un rebote rápido (scale up y scale down)
        await button.ScaleTo(1.2, 100, Easing.BounceIn);  // Aumentar el tamaño rápido
        await button.ScaleTo(1, 100, Easing.BounceOut);   // Volver al tamaño normal
    }
}

