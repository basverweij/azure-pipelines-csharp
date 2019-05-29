# Azure Pipelines CSharp

## Architecture

```text
AzurePipelines.Application --> AzurePipelines.Domain

AzurePipelines.Runner      --> AzurePipelines.Application
                           --> AzurePipelines.Infra.Emit
```