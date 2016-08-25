#joint_bayesianäººè„¸è¯†åˆ«
		C++å®ç°joint bayesianäººè„¸è¯†åˆ«ç®—æ³•
		C++/CLIå°è£…ç”ŸæˆC#å¯è°ƒç”¨dllæ–‡ä»¶

##å¹³å°åŠä¾èµ–é¡¹
		VS2013      
		eigençŸ©é˜µè¿ç®—åº“        

##ä»‹ç»

###jointbayesian_Csharp

VS2013çš„C#å·¥ç¨‹ï¼Œè°ƒç”¨dllæ–‡ä»¶è¿›è¡Œè®­ç»ƒä¸æµ‹è¯•

###joingbayesian_cli

VS2013çš„CLRå·¥ç¨‹ï¼Œç”¨C++å®ç°joint bayesianç®—æ³•ï¼Œå¹¶å¯¹joint bayesianç®—æ³•è¿›è¡ŒC++/CLIå°è£…ï¼Œç”ŸæˆC#å¯è°ƒç”¨çš„dllæ–‡ä»¶



##ä½¿ç”¨

å®ç°äº†JointbBayesian_CLIç±»ï¼Œæä¾›äº†3ä¸ªæ¥å£å‡½æ•°ä¾›C#è°ƒç”¨<br>

<<<<<<< HEAD
ÊµÏÖÁËJointbBayesian_CLIÀà£¬Ìá¹©ÁË4¸ö½Ó¿Úº¯Êı¹©C#µ÷ÓÃ<br>

* ÑµÁ·£ºbool train_jointbayesian(array<double,2>^ train_dataset,array<int>^train_label,int M,int N)<br>
¡¡¡¡¡¡¡¡ÊäÈë£ºtrain_dataset:ÑµÁ·¼¯£¬¶şÎ¬M*NÊı×é<br>
¡¡¡¡¡¡¡¡      train_label:ÑµÁ·¼¯±êÇ©£¬Ò»Î¬M*1Êı×é<br>
¡¡¡¡¡¡¡¡Êä³ö£º¼ÆËã³öÄ£ĞÍ¾ØÕóA,G,²¢´æ´¢ÎªdatÎÄ¼ş£¬ÑµÁ·³É¹¦·µ»Øtrue<br>

* ÅúÁ¿²âÊÔ£ºvoid test_jointbayesian(array<double, 2>^ test_dataset, array<int>^test_label, int M, int N)<br>
		¡¡¡¡ÊäÈë£ºtest_dataset£º²âÊÔ¼¯£¬¶şÎ¬M*NÊı×é<br>
		¡¡¡¡      test_label:²âÊÔ¼¯±êÇ©£¬Ò»Î¬M*1Êı×é<br>
		    Êä³ö£º¼ÆËã³ö²âÊÔ¼¯µÄratio,´æ´¢ÔÚÀàÖĞ£¬ÓÉperformance_jointbayesian£¨£©Ê¹ÓÃ<br>
* ĞÔÄÜ¼ÆËã£ºdouble performance_jointbayesian(double threshold_start, double threshold_end, double step£©<br>
        ÊäÈë£ºthreshold_start£ºãĞÖµÆğÊ¼Öµ <br>
              threshold_end:ãĞÖµ½áÊøÖµ<br>
              step:²½½ø³¤¶È<br>
				Êä³ö£ºµ±Ç°²âÊÔ¼¯ÏÂµÄ×î¼ÑãĞÖµ²¢·µ»Ø´ËÖµ
* µ¥¶ÔÍ¼Æ¬²âÊÔ£ºbool testpair_jointbayesian((array<double, 2>^ test_pair,double threshold,int M,int N)
				ÊäÈë£ºtest_pair£ºÒ»¶Ô²âÊÔÍ¼Æ¬<br>
							threshold:ÓÉ performance_jointbayesian()¼ÆËã³öµÄ×î¼ÑãĞÖµ
				Êä³ö£ºÅĞ¶¨Á½ÕÅÍ¼Æ¬ÊôÓÚÍ¬Ò»ÈË£¬·µ»Øtrue£»·ñÔò£¬·µ»Øfalse
ÑµÁ·½×¶Î£¬µ÷ÓÃtrain_jointbayesianº¯Êı<br>
ÅúÁ¿²âÊÔ½×¶Î£¬µ÷ÓÃtest_jointbayesianºÍperformance_jointbayesianº¯Êı<br>
=======
* è®­ç»ƒï¼švoid train_jointbayesian(array<double,2>^ train_dataset,array<int>^train_label,int M,int N)<br>
ã€€ã€€ã€€ã€€è¾“å…¥ï¼štrain_dataset:è®­ç»ƒé›†ï¼ŒäºŒç»´M*Næ•°ç»„<br>
ã€€ã€€ã€€ã€€ã€€ã€€ã€€ train_label:è®­ç»ƒé›†æ ‡ç­¾ï¼Œä¸€ç»´M*1æ•°ç»„<br>
ã€€ã€€ã€€ã€€è¾“å‡ºï¼šè®¡ç®—å‡ºæ¨¡å‹çŸ©é˜µA,G,å¹¶å­˜å‚¨ä¸ºdatæ–‡ä»¶

* æµ‹è¯•ï¼švoid test_jointbayesian(array<double, 2>^ test_dataset, array<int>^test_label, int M, int N)<br>
ã€€ã€€ã€€ã€€è¾“å…¥ï¼štest_datasetï¼šæµ‹è¯•é›†ï¼ŒäºŒç»´M*Næ•°ç»„ç»„<br>
ã€€ã€€ã€€ã€€ã€€ã€€ã€€test_label:è®­ç»ƒé›†æ ‡ç­¾ï¼Œä¸€ç»´M*Næ•°ç»„<br>
ã€€ã€€ã€€ã€€è¾“å‡ºï¼šè®¡ç®—å‡ºæµ‹è¯•é›†çš„ratio<br>
* æ€§èƒ½è®¡ç®—ï¼švoid performance_jointbayesian(double threshold_start, double threshold_end, double stepï¼‰<br>
ã€€ã€€ã€€ã€€è¾“å…¥ï¼šthreshold_startï¼šé˜ˆå€¼èµ·å§‹å€¼ <br>
ã€€ã€€ã€€ã€€ã€€ã€€ã€€threshold_end:é˜ˆå€¼ç»“æŸå€¼<br>
ã€€ã€€ã€€ã€€ã€€ã€€ã€€step:æ­¥è¿›é•¿åº¦<br>
ã€€ã€€ã€€ã€€è¾“å‡ºï¼šæœ€é«˜æ­£ç¡®ç‡å’Œå¯¹åº”é˜ˆå€¼<br>
è®­ç»ƒé˜¶æ®µï¼Œè°ƒç”¨train_jointbayesianå‡½æ•°<br>
æµ‹è¯•é˜¶æ®µï¼Œè°ƒç”¨test_jointbayesianå’Œperformance_jointbayesianå‡½æ•°<br>
>>>>>>> origin/master

