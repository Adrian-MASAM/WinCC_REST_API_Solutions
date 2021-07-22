CURL:
	Damit das DLL Projekt erstellt werden kann, muss die curl-Bibliothek auf dem Entwicklerrechner vorhanden sein.
	--> Einfach machbar mit Microsoft vcpkg --> https://github.com/microsoft/vcpkg

GMsgFunction.fct:
	Funktion, welche mit dem WinCC Global C-Script Editor geöffnet werden kann und die DLL WinCC_HTTP_POST_Client.dll verwendet.
	C-Code als Text:

	BOOL GMsgFunction( char* pszMsgData)
	{
	#pragma code ("C:\Program Files (x86)\Siemens\WinCC\bin\WinCC_C_VBS_HTTP_Client.dll")
	int HTTP_Post_Client(int MsgNr,int MsgState, char text[1000]);
	#pragma code ()

	MSG_RTDATA_STRUCT mRT;
	MSG_CSDATA_STRUCT sM; // holds alarm info 
	MSG_TEXT_STRUCT tMeld; // holds message text info
	CMN_ERROR pError;   
	memset( &mRT, 0, sizeof( MSG_RTDATA_STRUCT ) );

	if( pszMsgData != NULL )
	{
		printf( "Meldung : %s \r\n", pszMsgData );
		// Meldungsdaten einlesen
		sscanf( pszMsgData,  "%ld,%ld,%04d.%02d.%02d,%02d:%02d:%02d:%03d,%ld, %ld, %ld, %d,%d",
		&mRT.dwMsgNr, 			// Meldungsnummer
		&mRT.dwMsgState,  			// Status MSG_STATE_COME, .._GO, .._QUIT, .._QUIT_SYSTEM
		&mRT.stMsgTime.wYear, 		// Tag
		&mRT.stMsgTime.wMonth, 		// Monat
		&mRT.stMsgTime.wDay,		// Jahr
		&mRT.stMsgTime.wHour, 		// Stunde
		&mRT.stMsgTime.wMinute,		// Minute
		&mRT.stMsgTime.wSecond, 		// Sekunde
		&mRT.stMsgTime.wMilliseconds,	// Millisekunde
		&mRT.dwTimeDiff,			// Zeitdauer der anstehenden Meldung
		&mRT.dwCounter,			// Interner Meldungszähler
		&mRT.dwFlags,			// Flags( intern )
		&mRT.wPValueUsed,
		&mRT.wTextValueUsed );
      		// Prozesswerte lesen, falls gewünscht
	} 

 	if(mRT.dwMsgState == MSG_STATE_COME) //Nur bei Meldung gekommen - only coming messages
    	{
		MSRTGetMsgCSData(mRT.dwMsgNr, &sM, &pError);  
		// gets the text associated with the text ID (text library)
    		MSRTGetMsgText( 0, sM.dwTextID[0], &tMeld, &pError);
		// returned text is in tMeld.szText 
		HTTP_Post_Client(mRT.dwMsgNr,mRT.dwMsgState, tMeld.szText);
    		printf("Text: %s \r\n", tMeld.szText);
    	}

	//printf("Nr : %d, St: %x, %d-%d-%d %d:%d:%d.%d, Dur: %d, Cnt %d, Fl %d\r\n" , 
	//mRT.dwMsgNr, mRT.dwMsgState, mRT.stMsgTime.wDay, mRT.stMsgTime.wMonth, mRT.stMsgTime.wYear, 
	//mRT.stMsgTime.wHour, mRT.stMsgTime.wMinute, mRT.stMsgTime.wSecond, mRT.stMsgTime.wMilliseconds, mRT.dwTimeDiff,
	//mRT.dwCounter, mRT.dwFlags ) ;
	return( TRUE );
	}


