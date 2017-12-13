using UnityEngine;
using System.Collections;

public class GoBackToQuestion: DialogueTrigger {

	public int id;
	public int messageId;

	public override void FireTrigger (){
		if (triggerOnce && triggered)
		{
			return;
		}
		triggered = true;

		//GetComponentInParent<BaseDialogue>().ChangeDialogueToID(id, false);
		GetComponentInParent<BaseDialogue> ().BackToMessage(messageId,false);
	}
}
