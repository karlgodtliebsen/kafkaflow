/* eslint-disable */
/* eslint-disable */
export interface TopicPartitionAssignment {
  instanceName: string;
  lag?: number;
  lastUpdate?: string;
  pausedPartitions?: null | Array<number>;
  runningPartitions?: null | Array<number>;
  status: string;
  topicName: string;
}
