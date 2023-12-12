from yandex_tracker_client import TrackerClient
client = TrackerClient(token='y0_AgAAAABAp238AAr58gAAAAD0j5bADse4y-HYQTeUEBjyRC9h5MCBET8', cloud_org_id='bpfc89378a46ob3atafo')
client.issues.create(
    queue="TEAMCITYBUILDFA",
    summary="Build Fail",
    assignee="ogn3va.4"
)
