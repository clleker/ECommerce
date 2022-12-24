

namespace ECommerce.CoreApplication.ObjectDesign.Services
{
    [Serializable]
    public sealed class ServiceResponse<TResult> : ServiceResponse
    {
        public ServiceResponse(TResult result, bool isSuccessful = true)
            : base(isSuccessful)
        {
            this.Result = result;
        }

        public ServiceResponse(TResult result, ErrorInfo error, bool isSuccessful = false)
            : base(error, isSuccessful)
        {
            this.Result = result;
        }

        public TResult Result { get; set; }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is ServiceResponse<TResult> other && this.Equals(other));
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TResult>.Default.GetHashCode(this.Result);
        }

        private bool Equals(ServiceResponse<TResult> other)
        {
            return EqualityComparer<TResult>.Default.Equals(this.Result, other.Result);
        }
    }
}
