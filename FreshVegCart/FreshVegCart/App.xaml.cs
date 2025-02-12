﻿namespace FreshVegCart;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new(new MainPage()) { Title = "FreshVegCart" };
    }
}
