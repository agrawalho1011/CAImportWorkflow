select * from hblactivity ha inner join HblEntry he on ha.HblId = he.Id
inner join FileEntry fe on fe.id = he.FileGuidId where he.FileGuidId = 'f910ca2f-120a-45e0-bb12-cd8b23d08f4a' 
and ha.CurrentStatus ='Query' or ha.CurrentStatus = 'Completed With Query'

select * from hblactivity ha inner join HblEntry he on ha.HblId = he.Id
inner join FileEntry fe on fe.id = he.FileGuidId where he.FileGuidId = 'a6cf97f5-6f50-4fd5-a33c-f567263a29fb' 
and ha.CurrentStatus ='Query' or ha.CurrentStatus = 'Completed With Query'

select * from FileEntry where FileNo = '21321312312'

Select  HblActivity.* from FileEntry 
inner join HblEntry 
on FileEntry.Id = HblEntry.FileGuidId 
inner join HblActivity 
on HblActivity.HblId = HblEntry.Id 
where HblActivity.CurrentStatus ='Query' OR HblActivity.CurrentStatus ='Completed With Query'

Select * from HblActivity