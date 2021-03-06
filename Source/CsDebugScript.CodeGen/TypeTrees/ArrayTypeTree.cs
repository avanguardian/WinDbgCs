﻿namespace CsDebugScript.CodeGen.TypeTrees
{
    /// <summary>
    /// Type tree that represents pointer type.
    /// </summary>
    /// <seealso cref="TypeTree" />
    internal class ArrayTypeTree : TypeTree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayTypeTree"/> class.
        /// </summary>
        /// <param name="elementType">The element type tree.</param>
        public ArrayTypeTree(TypeTree elementType)
        {
            ElementType = elementType;
        }

        /// <summary>
        /// Gets the element type tree.
        /// </summary>
        public TypeTree ElementType { get; private set; }

        /// <summary>
        /// Gets the string representing this type tree in C# code.
        /// </summary>
        /// <param name="truncateNamespace">if set to <c>true</c> namespace will be truncated from generating type string.</param>
        /// <returns>
        /// The string representing this type tree in C# code.
        /// </returns>
        public override string GetTypeString(bool truncateNamespace = false)
        {
            return string.Format("CodeArray<{0}>", ElementType.GetTypeString(truncateNamespace));
        }
    }
}
