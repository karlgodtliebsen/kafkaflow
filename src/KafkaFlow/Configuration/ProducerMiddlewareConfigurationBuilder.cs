namespace KafkaFlow.Configuration
{
    using System.Collections.Generic;

    internal class ProducerMiddlewareConfigurationBuilder
        : IProducerMiddlewareConfigurationBuilder
    {
        private readonly List<Factory<IMessageMiddleware>> middlewaresFactories = new();

        public ProducerMiddlewareConfigurationBuilder(IDependencyConfigurator dependencyConfigurator)
        {
            this.DependencyConfigurator = dependencyConfigurator;
        }

        public IDependencyConfigurator DependencyConfigurator { get; }

        public IProducerMiddlewareConfigurationBuilder Add<T>(Factory<T> factory)
            where T : class, IMessageMiddleware
        {
            this.middlewaresFactories.Add(factory);
            return this;
        }

        public IProducerMiddlewareConfigurationBuilder Add<T>()
            where T : class, IMessageMiddleware
        {
            this.DependencyConfigurator.AddTransient<T>();
            this.middlewaresFactories.Add(resolver => resolver.Resolve<T>());
            return this;
        }

        public MiddlewareConfiguration Build() => new(this.middlewaresFactories);
    }
}
