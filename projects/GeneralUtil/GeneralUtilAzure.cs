
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace GeneralUtil
{
    public class GeneralUtilAzure
    {

        ///from Serra
        /// <summary>
        /// /https://referbruv.com/blog/posts/writing-a-simple-file-to-azure-storage-in-an-aspnet-core-application
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static  async Task<string> WriteToFolder(string folderName, string fileName, byte[] content)
        {
            try
            {
                fileName = folderName + "/" + fileName;
                string blobStorageConnString = "DefaultEndpointsProtocol=https;AccountName=tasawuq;AccountKey=KLm75f/iPUoSHD0aOGG2isYMnmg81U/uyg4tkJKlHD/3DGFBLUaDZ05BvKno/bhsz+XLoym/3YCRBLFxwGRP6A==;EndpointSuffix=core.windows.net";// _config["AzureBlobStorage:ConnectionString"].ToString();
                string containerName = "tasawuq";
                CloudStorageAccount account = null;
                // Lookup for a CloudStorageAccount for the given ConnectionString
                // if available fetch out the Account reference
                // under the _csAccount
                if (CloudStorageAccount.TryParse(blobStorageConnString, out account))
                {
                    // create a Client to access the Containers from the Account
                    CloudBlobClient cloudBlobClient = account.CreateCloudBlobClient();
                    // get the container reference from the account via the client
                    CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
                    // check if container exists or not
                    if (!await container.ExistsAsync())
                    {
                        // create container for the given name
                        await container.CreateAsync();
                        // set the container permissions for public 
                        // restricted to blob level only
                        BlobContainerPermissions permissions = new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        };
                        await container.SetPermissionsAsync(permissions);
                    }
                    // get the blob reference - creates a blob in the container
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                    // write content to the blob
                    await blockBlob.UploadFromByteArrayAsync(content, 0, content.Length);
                    //  await blockBlob.UploadTextAsync(content);
                    return blockBlob.Uri.AbsoluteUri;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return string.Empty;
        }
    }
}
