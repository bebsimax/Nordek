using Nordek.ViewModels;

namespace Nordek.Commands;

public class ShowVerbsCommand : CommandBase
{
    private RepeatVerbsViewModel _viewModel;

    public ShowVerbsCommand(RepeatVerbsViewModel viewModel)
    {
        _viewModel = viewModel;
    }
    public override void Execute(object parameter)
    {
        _viewModel.Infinitiv = _viewModel.v.Infinitiv;
        _viewModel.Presens = _viewModel.v.Presens;
        _viewModel.Preteritum = _viewModel.v.Preteritum;
        _viewModel.PreteritumPerfektum = _viewModel.v.PreteritumPerfektum;
    }
}