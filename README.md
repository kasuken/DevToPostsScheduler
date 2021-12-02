
# Dev.to posts scheduler

![](https://countrush-prod.azurewebsites.net/l/badge/?repository=kasuken.devtopostsscheduler)

A simple implementation to schedule posts on Dev.to.
## Deployment

To deploy this project, create an Azure Function on Azure based on .NET 6 and Function 4 runtime.
You can deploy the project directly from Visual Studio 2022 or you can create your own GitHub Actions.

## Environment Variables

To run this project, you will need to add the following environment variables to your local.settings.json file

`DevToApiKey`

To retrieve an API key, go to dev.to and login with your credentials.
Go to the page: https://dev.to/settings/account
In the "DEV API Keys" section create a new key by adding a description and clicking on "Generate API Key"

![](https://user-images.githubusercontent.com/146201/64421366-af3f8b00-d0a1-11e9-8ff6-7cc0ca6e854e.png)

You'll see the newly generated key in the same view

![](https://user-images.githubusercontent.com/146201/64421367-af3f8b00-d0a1-11e9-9831-73d3bdfdff66.png)

## Hot to use
After the deployment of the Azure Function, you can just add the markdown below in your article and save it as "Draft":

##ToPublishOn:2021-12-02 08:00AM##

## Contributing

Contributions are always welcome!

Fork the project and enjoy.


## Support

For support, add an issue directly in this repository: https://github.com/kasuken/DevToPostsScheduler/issues/new


## License

[MIT](https://choosealicense.com/licenses/mit/)


