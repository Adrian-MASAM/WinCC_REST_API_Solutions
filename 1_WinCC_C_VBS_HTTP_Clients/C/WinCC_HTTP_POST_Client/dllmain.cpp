#include "pch.h"
#include <curl/curl.h>
#include <string>
#include <exception>
#include <iostream>

//Referenzen:
//https://support.industry.siemens.com/cs/document/8301801/wie-k%C3%B6nnen-selbsterstellte-dlls-in-wincc-eingebunden-werden-?dti=0&lc=de-CH
//https://www.programmersought.com/article/22714254419/

extern "C" __declspec (dllexport) int HTTP_Post_Client(int MsgNr, int MsgState, char* text)
{
	//The following is the json data format
	char szJsonData[1024];
	memset(szJsonData, 0, sizeof(szJsonData));
	std::string aa = std::to_string(MsgNr);
	std::string bb = std::to_string(MsgState);
	std::string cc = (text);
	std::string strJson = "{";
	strJson += "\"ConditionName\" : \"" + aa + "\",";
	strJson += "\"State\" : \"" + bb + "\",";
	strJson += "\"Message\" : \"" + cc + "\"";
	strJson += "}";
	strcpy_s(szJsonData, strJson.c_str());

	try
	{
		CURL* pCurl = NULL;

		CURLcode res;
		// In windows, this will init the winsock stuff
		curl_global_init(CURL_GLOBAL_ALL);
		// get a curl handle
		pCurl = curl_easy_init();
		if (NULL != pCurl)
		{
			// Set the timeout time to 1 second
			curl_easy_setopt(pCurl, CURLOPT_TIMEOUT, 1);

			// First set the URL that is about to receive our POST. 
			// This URL can just as well be a 
			// https:// URL if that is what should receive the data.
			curl_easy_setopt(pCurl, CURLOPT_URL, "http://192.168.52.1:8080/api/newevent");


			// Set the content type sent by http to JSON
			curl_slist* plist = curl_slist_append(NULL,
				"Content-Type:application/json;charset=UTF-8");
			curl_easy_setopt(pCurl, CURLOPT_HTTPHEADER, plist);

			// Set the JSON data to be POSTed
			curl_easy_setopt(pCurl, CURLOPT_POSTFIELDS, szJsonData);

			// Perform the request, res will get the return code 
			res = curl_easy_perform(pCurl);
			// Check for errors
			return(res);
			// always cleanup
			curl_easy_cleanup(pCurl);

		}
		curl_global_cleanup();
	}
	catch (std::exception& ex)
	{
		printf("curl exception %s.\n", ex.what());
	}


}



