using Marketplace.Application.Contracts.V1;
using Marketplace.Domain.Contexts.Ad.DomainService;
using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using System.Reflection.Metadata;

namespace Marketplace.Application.Services.Ad;
public class ClassifiedAdApplicationService(IClassifiedAdRepository classifiedAdRepository, ICurrencyLookup currencyLookup) : IApplicationService
{
    private readonly IClassifiedAdRepository _classifiedAdRepository = classifiedAdRepository;
    private readonly ICurrencyLookup _currencyLookup = currencyLookup;

    public async Task Handle(AbstractContract command)
    {
        switch (command)
        {
            case Create cmd:
                await HandleCreate(cmd);
                break;

            case SetTitle cmd:
                await HandleUpdate(cmd.Id, classifiedAd =>
                    classifiedAd.SetTitle(ClassifiedAdTitle.FromString(cmd.Title)));
                break;

            case UpdateText cmd:
                await HandleUpdate(cmd.Id, classifiedAd =>
                    classifiedAd.UpdateText(ClassifiedAdText.FromString(cmd.Text)));
                break;

            case UpdatePrice cmd:
                await HandleUpdate(cmd.Id, classifiedAd =>
                    classifiedAd.UpdatePrice(Money.FromDecimal(cmd.Price, cmd.CurrencyCode, _currencyLookup)));
                break;

            case RequestToPublish cmd:
                await HandleUpdate(cmd.Id, classifiedAd => classifiedAd.RequestToPublish());
                break;

            default:
                throw new InvalidOperationException($"Command type {command.GetType().FullName} is unknown.");
        }


    }

    private async Task<ClassifiedAd> GetClassifiedAd(Guid classifiedAdId)
        => await _classifiedAdRepository.Load<ClassifiedAd>(classifiedAdId.ToString()) ?? throw new InvalidOperationException($"Classified ad id : {classifiedAdId} cannot be found");
    private async Task HandleCreate(Create cmd)
    {
        if (await _classifiedAdRepository.Exists<ClassifiedAd>(cmd.Id.ToString()))
            throw new InvalidOperationException($"Classified ad id : {cmd.Id} already exists");
        ClassifiedAd classifiedAd = new(new ClassifiedAdId(cmd.Id), new UserId(cmd.OwnerId));
        await _classifiedAdRepository.Save(classifiedAd);
    }

    private async Task HandleUpdate(Guid classifiedAdId, Action<ClassifiedAd> operation)
    {
        var classifiedAd = await GetClassifiedAd(classifiedAdId);
        operation(classifiedAd);
        await _classifiedAdRepository.Save(classifiedAd);
    }
}
