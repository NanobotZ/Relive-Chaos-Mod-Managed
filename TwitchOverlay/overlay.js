let totalVotesCounter = null;
let voteOptionsContainer = null;
let webSocketClient = null;
let webSocketTimeout = null;
let optionList = [];

function startWebSocket()
{
	if (webSocketClient === null)
	{
		webSocketTimeout = setTimeout(onWebSocketClose, 5000);
		webSocketClient = new WebSocket('ws://localhost:42069');
		webSocketClient.addEventListener('open', onWebSocketOpen);
		webSocketClient.addEventListener('message', onWebSocketMessage);
		webSocketClient.addEventListener('error', onWebSocketError);
		webSocketClient.addEventListener('close', onWebSocketClose);
	}
}

function stopWebSocket()
{
	if (webSocketClient === null)
		return;
	
	webSocketClient.close();
	webSocketClient = null;
}

function removeElemsPastIndex(index)
{
	for (let i = index; i < optionList.length; i++)
	{
		if (optionList[i])
		{
			optionList[i].div.remove();
			delete optionList[i];
		}
	}
}

function handleOption(data)
{
	if (optionList[data.index - 1])
	{
		let optionElem = optionList[data.index - 1];
		optionElem.index.textContent = data.index;
		optionElem.name.textContent = data.name;
		optionElem.votes.textContent = data.votes;
	}
	else
	{
		let optionDiv = document.createElement('div');
		optionDiv.classList.add('option');
		
		let optionIndex = document.createElement('span');
		optionIndex.classList.add('option_label');
		optionIndex.textContent = data.index;
		optionDiv.appendChild(optionIndex);
		
		let optionIndexNameSeparator = document.createElement('span');
		optionIndexNameSeparator.classList.add('option_label');
		optionIndexNameSeparator.textContent = '. ';
		optionDiv.appendChild(optionIndexNameSeparator);
		
		let optionName = document.createElement('span');
		optionName.classList.add('option_label');
		optionName.textContent = data.name;
		optionDiv.appendChild(optionName);
		
		// let optionNameVotesSeparator = document.createElement('span');
		// optionNameVotesSeparator.classList.add('option_label');
		// optionNameVotesSeparator.textContent = ': ';
		// optionDiv.appendChild(optionNameVotesSeparator);
		
		let optionVotes = document.createElement('span');
		optionVotes.classList.add('option_label');
		optionVotes.classList.add('option_label_vote');
		optionVotes.textContent = data.votes;
		optionDiv.appendChild(optionVotes);
		
		voteOptionsContainer.appendChild(optionDiv);
		
		
		let newOptionElem = {
			div: optionDiv,
			index: optionIndex,
			name: optionName,
			votes: optionVotes
		};
		optionList[data.index - 1] = newOptionElem;
	}
}

function onWebSocketOpen(open)
{
	clearTimeout(webSocketTimeout);
}

function onWebSocketMessage(event)
{
	if (event && event.data && typeof(event.data) === 'string')
	{
		let data = JSON.parse(event.data);
		
		if (data)
		{
			if (typeof(data.totalVotes) === 'number')
			{
				totalVotesCounter.textContent = 'Total votes: ' + data.totalVotes;
			}
			
			if (data.options && typeof(data.options.length) === 'number')
			{
				removeElemsPastIndex(data.options.length);
				
				if (data.options.length > 0)
				{
					data.options.forEach(handleOption);
				}
			}
		}
	}
}

function onWebSocketError(event)
{
	console.log(event);
}

function onWebSocketClose(event)
{
	stopWebSocket();
	
	totalVotesCounter.textContent = 'Waiting for game...';
	removeElemsPastIndex(0);
	
	window.setTimeout(startWebSocket, 1000);
}

document.addEventListener('DOMContentLoaded', function()
{
   totalVotesCounter = document.getElementById('total_votes');
   voteOptionsContainer = document.getElementById('option_container');
   
   // handleOption({index: 1, name: "Example 1", votes: 21});
   // handleOption({index: 2, name: "Example 2", votes: 37});
   // handleOption({index: 3, name: "Longer Example 3", votes: 1337});
   
   startWebSocket();
}, false);