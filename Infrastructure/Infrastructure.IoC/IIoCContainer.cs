using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    /// <summary>
    /// We are creating here Conforming Container, which is sometimes being pointed as <a href="http://blog.ploeh.dk/2014/05/19/conforming-container/">Anti-Pattern</a>. But
    /// used properly, it can avoid common pitfals while providing obvious benefit: easy repleacability.
    /// Refering to the negative consequences of
    /// Calls to the Conforming Container are likely to be sprinkled liberally over an entire code base.
    /// <ul>
    /// <li>It pushes novice users towards the Service Locator anti-pattern.Most people encountering Dependency Injection 
    /// for the first time mistake it for the Service Locator anti-pattern, despite the entirely opposite natures of these 
    /// two approaches to loose coupling.</li>
    /// <li>It attempts to relieve symptoms of bad design, instead of addressing the underlying problem. Too many 'loosely 
    /// coupled' designs attempt to rely on the Service Locator anti-pattern, which, by default, introduces a dependency to 
    /// a concrete Service Locator throughout a code base. However, exclusively using the Constructor Injection and Composition 
    /// Root design patterns eliminate the problem altogether, resulting in a simpler design with fewer moving parts.</li>
    /// <li>It pulls in the direction of the lowest common denominator.</li>
    /// <li>It stifles innovation, because new, creative, but radical ideas may not fit into the narrow view of the world a 
    /// Conforming Container defines.</li>
    /// <li>It makes it more difficult to avoid using a DI Container.A DI Container can be useful in certain scenarios, but 
    /// often, hand-coded composition is better than using a DI Container.However, if a library or framework depends on a 
    /// Conforming Container, it may be difficult to harvest the benefits of hand-coded composition.</li>
    /// <li>It may introduce versioning hell.Imagine that you need to use a library that depends on Confainer 1.3.7 in an 
    /// application that also uses a framework that depends on Confainer 2.1.7. Since a Conforming Container is intended 
    /// as an infrastructure component, this is likely to happen, and to cause much grief.</li>
    /// <li>A Conforming Container is often a product of Speculative Generality, instead of a product of need. As such, 
    /// the API is likely to be poorly suited to address real-world scenarios, be difficult to extent, and may exhibit churn 
    /// in the form of frequent breaking changes.</li>
    /// <li>If Adapters are supplied by contributors (often the DI Container maintainers themselves), the Adapters may have 
    /// varying quality levels, and may not support the latest version of the Conforming Container.</li>
    /// </ul>
    /// We want to make DI Container hidden for programmer to not introduce <a href="http://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/">Service Locator Anit-Pattern</a>.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IIoCContainer : IDisposable
    {
        /// <summary>
        /// Configures the specified modules and additionaly registers ASP.NET Core services.
        /// </summary>
        /// <param name="services">The services from ASP.NET Core pipeline to be registered in the container.</param>
        /// <param name="modules">The modules that registers its own types.</param>
        void Configure(IEnumerable<IIoCModule> modules, IServiceCollection services);

        /// <summary>
        /// Gets the ASP.NET Core service provider wrapper.
        /// </summary>
        IServiceProvider GetServiceProvider();
    }
}
