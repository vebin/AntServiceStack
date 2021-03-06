namespace AntServiceStack.FluentValidation
{
    using Internal;

    public class ValidationContext<T> : ValidationContext {
        public ValidationContext(T instanceToValidate) : this(instanceToValidate, new PropertyChain(), new DefaultValidatorSelector()) {
            
        }

        public ValidationContext(T instanceToValidate, PropertyChain propertyChain, IValidatorSelector validatorSelector)
            : base(instanceToValidate, propertyChain, validatorSelector) {

            InstanceToValidate = instanceToValidate;
        }

        public new T InstanceToValidate { get; private set; }
    }

    public class ValidationContext {

        public ValidationContext(object instanceToValidate)
         : this (instanceToValidate, new PropertyChain(), new DefaultValidatorSelector()){
            
        }

        public ValidationContext(object instanceToValidate, PropertyChain propertyChain, IValidatorSelector validatorSelector) {
            PropertyChain = new PropertyChain(propertyChain);
            InstanceToValidate = instanceToValidate;
            Selector = validatorSelector;
        }

        public PropertyChain PropertyChain { get; private set; }
        public object InstanceToValidate { get; private set; }
        public IValidatorSelector Selector { get; private set; }
        public bool IsChildContext { get; internal set; }

        public ValidationContext Clone(PropertyChain chain = null, object instanceToValidate = null, IValidatorSelector selector = null) {
            return new ValidationContext(instanceToValidate ?? this.InstanceToValidate, chain ?? this.PropertyChain, selector ?? this.Selector);
        }

        internal ValidationContext CloneForChildValidator(object instanceToValidate) {
            return new ValidationContext(instanceToValidate, PropertyChain, Selector) {
                IsChildContext = true
            };
        }
    }
}