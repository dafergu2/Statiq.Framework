﻿using System.Collections.Generic;

namespace Statiq.Common
{
    /// <summary>
    /// A module that can contain child modules.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Implementing modules should be careful not to accept <see cref="IEnumerable{IModule}"/> as a constructor
    /// parameter because doing so and then passing an <see cref="IContainerModule"/> as a direct child could
    /// add the modules from the child container module directly to the parent instead of adding the
    /// actual child container module.
    /// </para>
    /// <para>
    /// Implementing types should also provide an empty constructor to allow collection
    /// initialization syntax to work, or at least be sure that a constructor overload exists
    /// that does not require specifying child modules in the constructor.
    /// </para>
    /// <para>
    /// It's also recommended that if a module accepts child modules they are guaranteed to always execute.
    /// If the child modules are only executed under certain conditions (like if a config delegate is not
    /// specified) then it's recommended the module be split into multiple modules, one of which is
    /// responsible for executing child modules.
    /// </para>
    /// </remarks>
    public interface IContainerModule : IModule, IEnumerable<IModule>
    {
        /// <summary>
        /// The children of this module.
        /// </summary>
        IModuleList Children { get; }

        /// <summary>
        /// Adds modules as a child of this module.
        /// </summary>
        /// <remarks>
        /// This method is primarily to support collection initializer syntax for
        /// container modules. Child modules of this module can be more directly
        /// manipulated with the <see cref="Children"/> property.
        /// </remarks>
        /// <param name="modules">The modules to add.</param>
        void Add(params IModule[] modules);
    }
}