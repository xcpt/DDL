﻿function getEvent()
{
	if(document.all)
	{
		return window.event;//如果是ie
	}
	func=getEvent.caller;
	while(func!=null)
	{
		var arg0=func.arguments[0];
		if(arg0)
		{
			if((arg0.constructor==Event || arg0.constructor ==MouseEvent)||(typeof(arg0)=="object" && arg0.preventDefault && arg0.stopPropagation))
			{
				return arg0;
			}
		}
		func=func.caller;
	}
	return null;
}