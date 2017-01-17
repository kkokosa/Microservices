using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TicketService.Controllers
{
    public class RestCall<TRequest, TResponse> : IPropagatorBlock<TRequest, TResponse>
        where TResponse : class
    {
        private readonly TransformBlock<TRequest, TResponse> innerBlock;

        public RestCall(string address)
        {
            this.innerBlock = new TransformBlock<TRequest, TResponse>(_ => Invoker(_));
        }

        private TResponse Invoker(TRequest request)
        {
            return default(TResponse);
        }

        public Task Completion
        {
            get
            {
                return innerBlock.Completion;
            }
        }

        public void Complete()
        {
            innerBlock.Complete();
        }

        public TResponse ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TResponse> target, out bool messageConsumed)
        {
            return ((ISourceBlock<TResponse>)innerBlock).ConsumeMessage(messageHeader, target, out messageConsumed);
        }

        public void Fault(Exception exception)
        {
            ((IDataflowBlock)innerBlock).Fault(exception);
        }

        public IDisposable LinkTo(ITargetBlock<TResponse> target, DataflowLinkOptions linkOptions)
        {
            return innerBlock.LinkTo(target, linkOptions);
        }

        public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, TRequest messageValue, ISourceBlock<TRequest> source, bool consumeToAccept)
        {
            return ((ITargetBlock<TRequest>)innerBlock).OfferMessage(messageHeader, messageValue, source, consumeToAccept);
        }

        public void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TResponse> target)
        {
            ((ISourceBlock<TResponse>)innerBlock).ReleaseReservation(messageHeader, target);
        }

        public bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TResponse> target)
        {
            return ((ISourceBlock<TResponse>)innerBlock).ReserveMessage(messageHeader, target);
        }
    }
}
